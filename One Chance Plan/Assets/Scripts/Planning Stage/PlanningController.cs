using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlanningController : MonoBehaviour
{
    public Grid map;
    public Tilemap tilemap;
    private PlayerExecutionController player;

    private Queue<IAction> ActionQueue;
    private int ticks = 0;

    public void AddWait()
    {
        ActionQueue.Enqueue(new WaitAction(10));
    }

    public void AddInteraction()
    {
        //ActionQueue.Enqueue(new InteractAction());
    }

    public void AddMovement()
    {
        //ActionQueue.Enqueue(new MoveAction());
    }

    void Start()
    {
        ActionQueue = new Queue<IAction>();
        player = PlayerExecutionController.Instance;
        ActionQueue.Enqueue(new MoveAction(new Vector3Int(6,0,0)));
    }

    void Update()
    {
        if (ticks % 2 == 0)
            UpdateStep();

        ticks++;
    }

    private void UpdateStep()
    {
        if (ActionQueue.Count > 0)
        {
            bool canDequeue = ActionQueue.Peek().Execute();
            if (canDequeue)
                ActionQueue.Dequeue();
        }   
    }
}
