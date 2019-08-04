using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability where there are no working cameras
/// </summary>
public class Ability_NoCameras : Ability
{
    public Ability_NoCameras()
    {
        description = "No power, no cameras!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_NoCameras");
    }

    public override void Apply()
    {
        foreach (GameObject camera in MainGameController.Instance.GetActiveGameController().allCameras)
        {
            camera.GetComponent<SecurityCamera>().isActive = false;
            camera.GetComponentInChildren<FOV>().awarenessFactor = 0;
        }
    }
}
