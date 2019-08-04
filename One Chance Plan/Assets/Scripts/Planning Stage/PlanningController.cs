using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlanningController : GameController
{
    public GameObject Scene;


    public static PlanningController Instance;

    public Grid map;
    public Tilemap tilemap;

    public List<IAction> ActionQueue;

    public void AddWait()
    {
        ActionQueue.Add(new WaitAction(1));
    }

    public void AddInteraction(Interactable interactable)
    {
       ActionQueue.Add(new InteractAction(interactable));
    }

    public void AddMovement(Vector3Int direction)
    {
        ActionQueue.Add(new MoveAction(direction));
    }

    public void UndoAction()
    {
        if (ActionQueue.Count > 0)
        {
            ActionQueue[ActionQueue.Count - 1].Undo();
            ActionQueue.RemoveAt(ActionQueue.Count - 1);
        }
    }

    void Start()
    {
        ActionQueue = new List<IAction>();
        Instance = this;
    }

    public override void ActivateAlarm(bool status)
    {
        //
    }

    public override void Activate()
    {
        Scene.SetActive(true);
    }

    public override void Deactivate()
    {
        Scene.SetActive(false);
    }
}
