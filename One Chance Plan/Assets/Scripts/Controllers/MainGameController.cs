using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;

public class MainGameController : MonoBehaviour
{
    public GameObject visualizingStageController;
    public GameObject planningStageController;
    public GameObject executionStageController;

    public GameObject panelFirst;
    public GameObject panelStage1;
    public GameObject panelStage2;
    public GameObject panelStage3;

    [HideInInspector]
    public GameController activeGameController;
    public static MainGameController Instance;
    public List<Ability> abilities;

    public Canvas mainMenuUI;

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

        DOTween.Init();

        activeGameController = visualizingStageController.GetComponent<GameController>();

        LoadAbilities();
    }



    public void CreditsPressed()
    {

    }

    private void LoadAbilities()
    {
        abilities = new List<Ability>();

        abilities.Add(new Ability_NoPolice());
        abilities.Add(new Ability_NoCameras());
        abilities.Add(new Ability_AlertPolice());
        abilities.Add(new Ability_MissingKeys());
        abilities.Add(new Ability_LowPayPolice());
        abilities.Add(new Ability_UnlockedDoors());
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
    }

    public void PlayPressed()
    {
        panelFirst.gameObject.SetActive(true);

        StartCoroutine(Finish());

        panelFirst.gameObject.SetActive(false);
        panelStage1.gameObject.SetActive(true);

        StartCoroutine(Finish());

        panelStage1.gameObject.SetActive(false);

        activeGameController = visualizingStageController.GetComponent<GameController>();
        SetAbility();
        activeGameController.Activate();

        mainMenuUI.gameObject.SetActive(false);


    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(5f);
        // Do some stuff
    }


    public void MoveToPlanning()
    {
        panelStage2.gameObject.SetActive(true);

        //StartCoroutine(Finish());

        panelStage2.gameObject.SetActive(false);

        activeGameController.Deactivate();
        activeGameController = planningStageController.GetComponent<GameController>();
        activeGameController.Activate();
    }

    public void MoveToExecution()
    {
        panelStage3.gameObject.SetActive(true);

        StartCoroutine(Finish());

        panelStage3.gameObject.SetActive(false);

        activeGameController.Deactivate();
        activeGameController = executionStageController.GetComponent<GameController>();
        activeGameController.Activate();
    }

    public void MoveToEnd()
    {
        activeGameController.Deactivate();
        activeGameController = null;
    }
}
