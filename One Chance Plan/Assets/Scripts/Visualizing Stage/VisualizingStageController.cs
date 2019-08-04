using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizingStageController : GameController
{
    public GameObject abilityComponent;

    public static VisualizingStageController Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public override void Activate()
    {
        SetActiveState(true);
        isActive = true;
        abilityComponent.GetComponent<AbilityImage>().SetImage();
    }

    public override void Deactivate()
    {
        SetActiveState(false);
        ActivateAlarm(false);
        isActive = false;
    }

    private void SetActiveState(bool state)
    {
        foreach (GameObject police in allPolice)
        {
            police.GetComponent<PoliceControllerVisualization>().isActive = state;
        }  

        foreach (GameObject camera in allCameras)
        {
            camera.GetComponent<CameraControllerVisualization>().isActive = state;
        }

        GetActivePlayerController().GetComponent<PlayerControllerVisualization>().isActive = state;
    }


    void Update()
    {
        if (isActive)
        {
            if (GetActivePlayerController().GetComponent<PlayerControllerVisualization>().awareness > maxAwareness)
            {
                Deactivate();
            }
        }
    }

    public override void ActivateAlarm(bool status)
    {
        foreach (GameObject civilian in allCivilian)
        {
            civilian.GetComponent<CivilianControlerVisualization>().isActive = status;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            MainGameController.Instance.MoveToPlanning();
        }
    }
}
