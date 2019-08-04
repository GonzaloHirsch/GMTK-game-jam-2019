using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerExecutionController : PlayerController
{
    public static PlayerExecutionController Instance;

    public Tilemap map;

    public float velocity;
    public Vector2Int StartCellPosition;

    private static float DELTA = 0.005f;

    private Queue<Vector3Int> movePositions;
    public Vector3Int position;

    void Start()
    {
        if (Instance != null)
            Debug.LogError("There can only be on PlayerExecutionController class in the scene");
        Instance = this;
        movePositions = new Queue<Vector3Int>();
        position = (Vector3Int)StartCellPosition;
        transform.position = map.GetCellCenterWorld((Vector3Int)StartCellPosition);
        MainPlayerController.Instance.activePlayerController = this;
    }

    public void MoveTo(Vector3Int position)
    {
        this.position = position;
        movePositions.Enqueue(this.position);
        
    }

    public void Move(Vector3Int position)
    {
        this.position += position;
        movePositions.Enqueue(this.position);
        
    }

    void Update()
    {
        if (movePositions.Count > 0)
        {
            UpdateMovement();

            if (Vector2.Distance(transform.position, map.GetCellCenterWorld(movePositions.Peek())) < DELTA)
                transform.position = map.GetCellCenterWorld(movePositions.Dequeue());
        }
    }

    private void UpdateMovement()
    {
        float step = velocity * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, map.GetCellCenterWorld(movePositions.Peek()), step);
    }

    public override void Activate()
    {
        //
    }

    public override void Deactivate()
    {
        //
    }
}
