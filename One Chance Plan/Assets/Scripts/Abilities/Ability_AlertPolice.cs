using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_AlertPolice : Ability
{
    public float awarenessFactorIncrease = 3f;

    private void Start()
    {
        description = "High alert police!";

        sprite = Resources.Load<Sprite>("Sprites/Icons/Ability_AlertPolice");
    }

    public override void Apply()
    {
        foreach (GameObject police in MainGameController.Instance.GetActiveGameController().allPolice)
        {
            police.GetComponentInChildren<FOV>().awarenessFactor *= awarenessFactorIncrease;
        }
    }
}
