using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability where there are no working cameras
/// </summary>
public class Ability_NoCameras : Ability
{
    public new string description = "No power, no cameras!";

    public override void Apply()
    {
        foreach (GameObject camera in MainGameController.Instance.GetActiveGameController().allCameras)
        {
            camera.GetComponent<SecurityCamera>().isActive = false;
            camera.GetComponentInChildren<FOV>().awarenessFactor = 0;
        }
    }
}
