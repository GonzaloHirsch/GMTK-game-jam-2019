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
        foreach (GameObject cam in MainGameController.Instance.GetActiveGameController().allCameras)
        {
            cam.GetComponent<SecurityCamera>().isActive = false;
            cam.GetComponentInChildren<FOV>().awarenessFactor = 0;
        }
    }
}
