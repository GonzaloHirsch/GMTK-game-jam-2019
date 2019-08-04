using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public GameObject visualizingStagePlayerController;

    [HideInInspector]
    public GameObject activePlayerController;

    public static MainPlayerController Instance;

    public PlayerController GetActivePlayerController()
    {
        return activePlayerController.GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != this)
        {
            Destroy(this);
        }

        Instance = this;

        activePlayerController = visualizingStagePlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
