using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_NoPeople : Ability
{
    private void Start()
    {
        description = "No people, must be a holiday!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_NoPeople");
    }

    public override void Apply()
    {
        foreach (GameObject civilian in MainGameController.Instance.GetActiveGameController().allCivilian)
        {
            civilian.SetActive(false);
        }
    }
}
