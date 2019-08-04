using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionController : MonoBehaviour
{
    private int ticks = 0;

    private Queue<IAction> ActionQueue;

    void Start()
    {
        ActionQueue = new Queue<IAction>();
    }

    public void SetActionQueue(Queue<IAction> actionQueue)
    {
        this.ActionQueue = actionQueue;
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
