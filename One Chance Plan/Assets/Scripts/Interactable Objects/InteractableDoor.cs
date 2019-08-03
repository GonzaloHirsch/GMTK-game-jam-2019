using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    public GameObject key;

    void Start()
    {

    }

    public override void Interact()
    {
        Debug.Log("DOOR");
        // Verify that the active player contains the key to open that door
        if (MainPlayerController.Instance.GetActivePlayerController().keys.Contains(key))
        {
            Debug.Log("DOOR PERRAS");
            gameObject.SetActive(false);
        }

    }
}
