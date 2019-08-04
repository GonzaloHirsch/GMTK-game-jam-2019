using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_MissingKeys : Ability
{
    public new string description = "Missing keys!";

    public override void Apply()
    {
        foreach (GameObject key in MainGameController.Instance.GetActiveGameController().allKeys)
        {
            key.SetActive(false);
        }
    }
}
