using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityImage : MonoBehaviour
{
    Image image;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();

        playerController = MainPlayerController.Instance.GetActivePlayerController();
    }

    public void SetImage()
    {
        image.sprite = playerController.ability.sprite;
    }
}
