using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> keys;

    public GameObject player;

    public float awareness = 0;

    public void RaiseAwareness(float increment)
    {
        awareness += increment;
    }

    public bool isActive = false;

    /// <summary>
    /// This method initializes all important variables and sets the controller as active.
    /// </summary>
    public abstract void Activate();

    /// <summary>
    /// This method sets the controller as inactive
    /// </summary>
    public abstract void Deactivate();
}
