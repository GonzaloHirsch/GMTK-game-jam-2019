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
    public Vector2Int StartCellPosition;

    private Vector3Int position;

    void Start()
    {
        if (Instance != null)
            Debug.LogError("There can only be on PlayerPlanningController class in the scene");
        Instance = this;
        position = (Vector3Int)StartCellPosition;
        transform.position = map.GetCellCenterWorld((Vector3Int)StartCellPosition);
    }

    private void Update()
    {
        if (map.GetTile(map.WorldToCell(mainCamera.ScreenToWorldPoint(Input.mousePosition))) != null)
        {
            Vector3Int line = position - map.WorldToCell(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }

}
