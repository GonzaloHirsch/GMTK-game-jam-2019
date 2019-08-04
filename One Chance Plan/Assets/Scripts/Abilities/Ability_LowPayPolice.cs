using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_LowPayPolice : Ability
{
    public float awarenessFactorDecrease = 3f;

    public new string description = "Today it's Friday!";

    public override void Apply()
    {
        foreach (GameObject police in MainGameController.Instance.GetActiveGameController().allPolice)
        {
            police.GetComponentInChildren<FOV>().awarenessFactor /= awarenessFactorDecrease;
        }
    }
}
