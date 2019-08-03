using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAlarm : Interactable
{
    public override void Interact()
    {
        MainGameController.Instance.GetActiveGameController();
    }
}
