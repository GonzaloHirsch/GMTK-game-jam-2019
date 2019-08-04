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
    private Vector3 MoveTo = Vector3.zero;
    private List<Vector3Int> moveVertex;

    void Start()
    {
        if (Instance != null)
            Debug.LogError("There can only be on PlayerPlanningController class in the scene");
        Instance = this;
        position = (Vector3Int)StartCellPosition;
        transform.position = map.GetCellCenterWorld((Vector3Int)StartCellPosition);

        moveVertex = new List<Vector3Int>();
        moveVertex.Add((Vector3Int)StartCellPosition);
    }

    

    private void Update()
    {
        DrawSelection();
        SetPosition();
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

            MoveTo = line;
        }
    }

    private void DrawLineSegment(Vector3Int start, Vector3Int end, TileBase tile)
    {
        Vector3 tempLine = end - start;
        for (int i = 0; i <= tempLine.magnitude; i++)
        {
            highlightMap.SetTile(Vector3Int.CeilToInt(start + tempLine.normalized * i), tile);
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
        }
    }

    public TileBase GetStandingTile()
    {
        return map.GetTile(position);
    }
}
