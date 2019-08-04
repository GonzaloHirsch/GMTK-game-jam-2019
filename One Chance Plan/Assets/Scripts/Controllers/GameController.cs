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

    public GameObject activePlayer;

    public PlayerController GetActivePlayerController()
    {
        return activePlayer.GetComponent<PlayerController>();
    }

    public abstract void ActivateAlarm();
}
