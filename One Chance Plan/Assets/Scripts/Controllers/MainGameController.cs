using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameController : MonoBehaviour
{
    public GameObject visualizingStageController;
    public GameController activeGameController;
    public static MainGameController Instance;
    public List<Ability> abilities;

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

        LoadAbilities();
    }

    private void LoadAbilities()
    {
        abilities.Add(new Ability_NoPolice());
        abilities.Add(new Ability_NoCameras());
        abilities.Add(new Ability_AlertPolice());
        abilities.Add(new Ability_MissingKeys());
        abilities.Add(new Ability_LowPayPolice());
        abilities.Add(new Ability_UnlockedDoors());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
