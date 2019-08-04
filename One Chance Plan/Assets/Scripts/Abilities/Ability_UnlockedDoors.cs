using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_UnlockedDoors : Ability
{
    public new string description = "Forgot to lock doors!";

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
