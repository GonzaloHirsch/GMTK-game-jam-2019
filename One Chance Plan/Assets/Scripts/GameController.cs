using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameController : MonoBehaviour
{
    public GameObject activePlayer;

    public PlayerController GetActivePlayerController()
    {
        return activePlayer.GetComponent<PlayerController>();
    }

    public abstract void ActivateAlarm();
}
