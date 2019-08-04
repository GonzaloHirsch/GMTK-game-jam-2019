using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Empty : Ability
{
    public Ability_Empty()
    {
        description = "Your ability is to be normal!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_Empty");
    }

    public override void Apply()
    {
        foreach (GameObject key in MainGameController.Instance.GetActiveGameController().allKeys)
        {
            key.SetActive(false);
        }

        foreach (GameObject door in MainGameController.Instance.GetActiveGameController().allDoors)
        {
            door.SetActive(false);
        }
    }
}
