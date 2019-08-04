using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizingStageController : GameController
{
    public GameObject abilityComponent;
    public Canvas UI;

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
        UI.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        SetActiveState(true);
        isActive = true;
        abilityComponent.GetComponent<AbilityImage>().Activate();
        abilityComponent.GetComponent<AbilityImage>().SetImage();
    }

    public override void Deactivate()
    {
        UI.gameObject.SetActive(false);
        SetActiveState(false);
        ActivateAlarm(false);
        isActive = false;
        MainPlayerController.Instance.GetActivePlayerController().gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void SetActiveState(bool state)
    {
        foreach (GameObject police in allPolice)
        {
            police.GetComponent<PoliceControllerVisualization>().isActive = state;
        }  

        foreach (GameObject cam in allCameras)
        {
            cam.GetComponent<CameraControllerVisualization>().isActive = state;
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

        if (status)
        {
            foreach (GameObject civilian in allPolice)
            {
                civilian.GetComponent<PoliceControllerVisualization>().ChangePositions(2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            MainGameController.Instance.MoveToPlanning();
    }
}
