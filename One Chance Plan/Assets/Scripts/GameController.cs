using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton gamecontroller
    private GameController gameController;

    private void Awake()
    {
        // Singleton gamecontroller
        if (this.gameController != this)
        {
            Destroy(this.gameController);
        }

        this.gameController = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
