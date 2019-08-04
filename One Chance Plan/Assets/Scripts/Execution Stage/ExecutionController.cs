using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionController : GameController
{
    public ExecutionController Instance;

    private int ticks = 0;

    public int tickLimit = 6;

    private Queue<IAction> ActionQueue;

    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;

        ActionQueue = new Queue<IAction>();
    }

    public void SetActionQueue(Queue<IAction> actionQueue)
    {
        this.ActionQueue = actionQueue;
    }

    void Update()
    {
        if (ticks % tickLimit == 0)
            UpdateStep();

        ticks++;
    }

    private void UpdateStep()
    {
        if (ActionQueue.Count > 0)
        {
            bool canDequeue = ActionQueue.Peek().Execute();
            if (canDequeue)
                ActionQueue.Dequeue().Execute();
        }
    }

    public override void ActivateAlarm(bool status)
    {
        throw new System.NotImplementedException();
    }

    public override void Activate()
    {
        throw new System.NotImplementedException();
    }

    public override void Deactivate()
    {
        throw new System.NotImplementedException();
    }
}
