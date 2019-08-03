using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizingStageController : GameController
{
    public bool isActive = false;
    public List<GameObject> policeControllers;
    public List<GameObject> cameraControllers;
    public List<GameObject> civilianControllers;
    public GameObject player;

    public float maxAwareness = 200;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ActivateState()
    {
        SetActiveState(true);
        isActive = true;
    }

    private void SetActiveState(bool state)
    {
        foreach (GameObject police in policeControllers)
        {
            police.GetComponent<PoliceControllerVisualization>().isActive = state;
        }

        foreach (GameObject camera in cameraControllers)
        {
            camera.GetComponent<CameraControllerVisualization>().isActive = state;
        }

        player.GetComponent<PlayerControllerVisualization>().isActive = state;
    }

    public void EndStage()
    {
        SetActiveState(false);
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            if (player.GetComponent<PlayerControllerVisualization>().awareness > maxAwareness)
            {
                EndStage();
            }
        }
    }

    public override void ActivateAlarm()
    {
        throw new System.NotImplementedException();
    }
}
