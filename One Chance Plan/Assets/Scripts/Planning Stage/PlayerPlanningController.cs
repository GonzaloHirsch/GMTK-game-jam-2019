using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerPlanningController : MonoBehaviour
{
    public static PlayerPlanningController Instance;

    public Camera mainCamera;
    public Tilemap map;
    public Tilemap highlightMap;
    public TileBase pathTile;
    public TileBase highlightTile;


    public Vector2Int StartCellPosition; 

    public Vector3Int position;
    public Vector3 MoveTo = Vector3.zero;
    public List<Vector3Int> moveVertex;

    private Dictionary<Vector3Int, TileBase> actionMap;

    public bool isUsingUI = false;

    void Start()
    {
        if (Instance != null)
            Debug.LogError("There can only be on PlayerPlanningController class in the scene");
        Instance = this;
        position = (Vector3Int)StartCellPosition;
        transform.position = map.GetCellCenterWorld((Vector3Int)StartCellPosition);

        moveVertex = new List<Vector3Int>();
        moveVertex.Add((Vector3Int)StartCellPosition);
        actionMap = new Dictionary<Vector3Int, TileBase>();
    }

    private void Update()
    {
        if (!isUsingUI)
        {
            DrawSelection();
            SetPosition();
        }
    }

    public void UndoAction()
    {
        int i = 0;
        foreach(Vector3Int v in actionMap.Keys)
        {
            if (i == actionMap.Keys.Count-1)
            {
                highlightMap.SetTile(v, null);
                actionMap.Remove(v);
            }
        }
    }

    public void UndoMovement()
    {
        DrawLineSegment(position, Vector3Int.CeilToInt(position + MoveTo), null);
        position = moveVertex[moveVertex.Count - 2];
        DrawLineSegment(moveVertex[moveVertex.Count - 1], moveVertex[moveVertex.Count - 2], null);
        moveVertex.RemoveAt(moveVertex.Count - 1);
        transform.position = map.GetCellCenterWorld(position);
    }

    private void DrawSelection()
    {
        if (map.GetTile(map.WorldToCell(mainCamera.ScreenToWorldPoint(Input.mousePosition))) != null)
        {
            Vector3 line = map.WorldToCell(mainCamera.ScreenToWorldPoint(Input.mousePosition)) - position;
            if (Mathf.Abs(line.x) > Mathf.Abs(line.y))
                line.y = 0;
            else
                line.x = 0;
            for (int i = 0; i <= line.magnitude; i++)
            {
                if(map.GetTile(position + Vector3Int.CeilToInt(line.normalized * i)) == null){
                    line = (line.normalized * (i-1));
                    break;
                }
            }

            DrawLineSegment(position, Vector3Int.CeilToInt(position + MoveTo), null);
            
            for (int i = 0; i < moveVertex.Count - 1; i++)
            {

                DrawLineSegment(moveVertex[i], moveVertex[i + 1], pathTile);
            }
            DrawLineSegment(position, Vector3Int.CeilToInt(position + line), highlightTile);
            foreach(Vector3Int v in actionMap.Keys)
                highlightMap.SetTile(v, actionMap[v]);

            MoveTo = line;
        }
    }

    public void DrawLineSegment(Vector3Int start, Vector3Int end, TileBase tile)
    {
        Vector3 tempLine = end - start;
        for (int i = 0; i <= tempLine.magnitude; i++)
        {
            highlightMap.SetTile(Vector3Int.CeilToInt(start + tempLine.normalized * i), tile);
        }
    }

    

    public void SetActionTile(TileBase tile)
    {
        if (!actionMap.ContainsKey(position))
        {
            actionMap.Add(position, tile);
            highlightMap.SetTile(position, tile);
        }

    }

    private void SetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlanningController.Instance.AddMovement(Vector3Int.CeilToInt(MoveTo));
            position += Vector3Int.CeilToInt(MoveTo);
            MoveTo = Vector3.zero;
            transform.position = map.GetCellCenterWorld(position);
            moveVertex.Add(new Vector3Int(position.x, position.y,0));
            PlanningUIController.Instance.AddActionPanel(PlanningUIController.Instance.moveTexture);
        }
    }

    public TileBase GetStandingTile()
    {
        return map.GetTile(position);
    }
}
