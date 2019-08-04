using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    public GameObject visualizingStagePlayerController;

    [HideInInspector]
    public Ability ability;

    [HideInInspector]
    public PlayerController activePlayerController;

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
            Destroy(Instance);
        }

        Instance = this;

        ability = new Ability_Empty();

        activePlayerController = visualizingStagePlayerController.GetComponent<PlayerController>();
    }


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
