using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_MissingKeys : Ability
{
    private void Start()
    {
        description = "Missing keys!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_MissingKeys");
    }

    public override void Apply()
    {
        foreach (GameObject key in MainGameController.Instance.GetActiveGameController().allKeys)
        {
            key.SetActive(false);
        }
    }
}
