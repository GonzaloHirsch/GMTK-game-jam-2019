using  UnityEngine;

public interface IAction
{
    bool Execute();
    void Undo();
}


public class WaitAction : IAction
{
    private int steps;

    public WaitAction(int steps)
    {
        this.steps = steps;
    }

    public bool Execute()
    {
        Debug.Log(steps);
        steps--;
        return steps <= 0;
    }

    public void Undo()
    {
        PlayerPlanningController.Instance.UndoAction();
        Debug.Log("Undoing Wait");
    }
}

public class InteractAction : IAction
{
    public Interactable interactable;

    public InteractAction(Interactable interactable)
    {
        this.interactable = interactable;
    }

    public bool Execute()
    {
        interactable.Interact();
        return true;
    }

    public void Undo()
    {
        PlayerPlanningController.Instance.UndoAction();
        Debug.Log("Undoing Inter");
    }
}

public class MoveAction : IAction
{
    public Vector3Int position;
    private int steps;

    public bool Execute()
    {
        if (steps-- <= 0)
            return true;
        PlayerExecutionController.Instance.Move(getDirection(position));
        return false;
    }

    public MoveAction(Vector3Int position)
    {
        this.position = position;
        steps = (int)position.magnitude;
    }

    private Vector3Int getDirection(Vector3Int vector)
    {
        Vector3 vec3 = ((Vector3)vector);
        vec3.Normalize();
        Vector3Int ret = Vector3Int.FloorToInt(vec3);
        if (vec3.magnitude != 1)
        {
            Debug.LogError("Direction is in diagonal!");
        }
        return Vector3Int.FloorToInt(ret);

    }

    public void Undo() {
        PlayerPlanningController.Instance.UndoMovement();
        Debug.Log("Undoing movement");
    }
}