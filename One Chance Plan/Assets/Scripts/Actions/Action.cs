using  UnityEngine;

public abstract class Action
{
    public abstract bool Execute();
}


public class WaitAction : Action
{
    private int steps;

    public WaitAction(int steps)
    {
        this.steps = steps;
    }

    public override bool Execute()
    {
        steps--;
        return steps <= 0;
    }
}

public class InteractAction : Action
{
    public Interactable interactable;

    public InteractAction(Interactable interactable)
    {
        this.interactable = interactable;
    }

    public override bool Execute()
    {
        interactable.Interact();
        return true;
    }
}

public class MoveAction : Action
{

    public override bool Execute()
    {
        throw new System.NotImplementedException();
    }
}