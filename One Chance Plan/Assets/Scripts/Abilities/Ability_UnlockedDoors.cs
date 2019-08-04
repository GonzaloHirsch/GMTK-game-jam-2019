using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_UnlockedDoors : Ability
{
    public Ability_UnlockedDoors()
    {
        description = "Forgot to lock doors!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_UnlockedDoors");
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
