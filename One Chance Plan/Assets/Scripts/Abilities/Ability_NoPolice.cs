using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_NoPolice : Ability
{
    public new string description = "Police Union Strike!";

    public override void Apply()
    {
        foreach (GameObject police in MainGameController.Instance.GetActiveGameController().allPolice)
        {
            police.GetComponent<Police>().isActive = false;
            police.SetActive(false);
        }
    }
}
