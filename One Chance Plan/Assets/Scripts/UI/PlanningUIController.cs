using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlanningUIController : MonoBehaviour
{

    public Tilemap map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractButton()
    {
        Debug.Log(PlayerPlanningController.Instance.GetStandingTile().name);
        /*if(PlayerPlanningController.Instance.position)
        PlanningController.Instance.AddInteraction();*/
    }
}
