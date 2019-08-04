using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionController : GameController
{
    public static ExecutionController Instance;

    public Canvas UI;

    public GameObject player;

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

    public void SetActionQueue(List<IAction> actionQueue)
    {
        foreach(IAction action in actionQueue)
        {
            this.ActionQueue.Enqueue(action);
        }
    }

    void Update()
    {
        if (ticks % tickLimit == 0)
            UpdateStep();

        ticks++;

        if (isActive)
        {
            Debug.Log("asdasd");
            if (MainPlayerController.Instance.GetActivePlayerController().awareness > maxAwareness)
            {
                Deactivate();
                MainGameController.Instance.Lose();
            }
        }
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
        foreach (GameObject civilian in allCivilian)
        {
            civilian.GetComponent<CivilianControlerVisualization>().isActive = status;
        }

        if (status)
        {
            foreach (GameObject civilian in allPolice)
            {
                civilian.GetComponent<PoliceControllerVisualization>().ChangePositions(2);
            }
        }
    }

    public override void Activate()
    {
        isActive = true;
        foreach (GameObject police in allPolice)
        {
            police.GetComponent<PoliceControllerVisualization>().isActive = true;
        }

        foreach (GameObject cam in allCameras)
        {
            cam.GetComponent<CameraControllerVisualization>().isActive = true;  
        }
        player.SetActive(true);
        UI.gameObject.SetActive(true);
    }

    public override void Deactivate()
    {
        isActive = false;
        player.SetActive(false);
    }
}
