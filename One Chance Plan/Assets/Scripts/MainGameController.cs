using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public GameObject visualizingStageController;

    public GameController activeGameController;

    public static MainGameController Instance;

    public GameController GetActiveGameController()
    {
        return visualizingStageController.GetComponent<GameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
