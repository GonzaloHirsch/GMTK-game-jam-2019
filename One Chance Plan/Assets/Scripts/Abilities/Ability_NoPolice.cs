using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_NoPolice : Ability
{
    private void Start()
    {
        description = "Police Union Strike!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_NoPolice");
    }

    public override void Apply()
    {
        foreach (GameObject police in MainGameController.Instance.GetActiveGameController().allPolice)
        {
            police.GetComponent<Police>().isActive = false;
            police.SetActive(false);
        }
    }
}
