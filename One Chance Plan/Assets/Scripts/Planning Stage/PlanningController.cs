using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlanningController : MonoBehaviour
{
    public static PlanningController Instance;

    public Grid map;
    public Tilemap tilemap;

    private Queue<IAction> ActionQueue;

    public void AddWait()
    {
        ActionQueue.Enqueue(new WaitAction(10));
    }

    public void AddInteraction()
    {
        //ActionQueue.Enqueue(new InteractAction());
    }

    public void AddMovement(Vector3Int direction)
    {
        ActionQueue.Enqueue(new MoveAction(direction));
    }

    void Start()
    {
        ActionQueue = new Queue<IAction>();
        Instance = this;
    }

    
}
