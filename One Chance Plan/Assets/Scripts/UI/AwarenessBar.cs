using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AwarenessBar : MonoBehaviour
{
    Image foregroundImage;

    private float maxAwarenessValue;

    public float unitsPerSecond = 20;

    private float time;

    private GameController gameController;
    private PlayerController playerController;

    public float Value
    {
        get
        {
            if (foregroundImage != null)
                return foregroundImage.fillAmount * maxAwarenessValue;
            else
                return 0;
        }
        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value / maxAwarenessValue;
        }
    }

    void Start()
    {
        DOTween.Init();
        DOTween.SetTweensCapacity(1250, 50);

        gameController = MainGameController.Instance.GetActiveGameController();
        playerController = MainPlayerController.Instance.GetActivePlayerController();
        maxAwarenessValue = gameController.maxAwareness;
        foregroundImage = gameObject.GetComponent<Image>();
        Value = 0;
    } 

    void Update()
    {
        playerController = MainPlayerController.Instance.GetActivePlayerController();
        time = (playerController.awareness - foregroundImage.fillAmount) / unitsPerSecond;
        
        if (time > 1f)
        {
            DOTween.To(() => foregroundImage.fillAmount, x => foregroundImage.fillAmount = x, playerController.awareness / gameController.maxAwareness, time);
            time = 0f;
        }
    }

    public void TweenedSomeValue(int val)
    {
        Value = val;
    }

    public void OnFullProgress()
    {
        Value = 0;
    }
}
