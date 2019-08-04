using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameController : MonoBehaviour
{
    public List<GameObject> allCameras;
    public List<GameObject> allPolice;
    public List<GameObject> allCivilian;
    public List<GameObject> allKeys;
    public List<GameObject> allDoors;

    public bool isActive;

    public float maxAwareness = 200;

    public PlayerController GetActivePlayerController()
    {
        return MainPlayerController.Instance.GetActivePlayerController();
    }

    public abstract void ActivateAlarm(bool status);

    public abstract void Activate();

    public abstract void Deactivate();
}
