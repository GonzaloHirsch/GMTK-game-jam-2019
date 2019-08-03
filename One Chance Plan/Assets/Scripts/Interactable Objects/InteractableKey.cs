using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKey : Interactable
{
    public override void Interact()
    {
        MainPlayerController.Instance.GetActivePlayerController().keys.Add(this.gameObject);
        gameObject.SetActive(false);
    }
}
