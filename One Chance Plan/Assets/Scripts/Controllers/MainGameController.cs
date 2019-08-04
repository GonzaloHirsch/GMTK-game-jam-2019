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
    void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;

        activeGameController = visualizingStageController.GetComponent<GameController>();

        LoadAbilities();

        SetAbility();
    }

    private void Start()
    {

    }

    private void LoadAbilities()
    {
        abilities = new List<Ability>();

        abilities.Add(new Ability_NoPolice());
        abilities.Add(new Ability_NoCameras());
        //abilities.Add(new Ability_AlertPolice());
        //abilities.Add(new Ability_MissingKeys());
        //abilities.Add(new Ability_LowPayPolice());
        //abilities.Add(new Ability_UnlockedDoors());
        abilities.Add(new Ability_NoPeople());
        abilities.Add(new Ability_Empty());
    }

    private void SetAbility()
    {
        MainPlayerController.Instance.ability = abilities[Random.Range(0, abilities.Count)];
        MainPlayerController.Instance.ability.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            activeGameController.Activate();
        }
    }

    public void MoveToPlanning()
    {

    }
}
