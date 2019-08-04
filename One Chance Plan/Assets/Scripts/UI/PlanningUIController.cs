using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlanningUIController : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler
{

    public static PlanningUIController Instance;

    public Tilemap map;
    public Tilemap interactableMap;

    public Texture2D waitTexture;
    public Texture2D moveTexture;
    public Texture2D SpriteTexture;
    public Texture2D transitionTexture;

    public GameObject signPrefab;
    public GameObject actionQueuePanel;

    public TileBase waitingTile;
    public TileBase interactionTile;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractButton()
    {
        GameObject interactable = null;
        try
        {
            interactable = interactableMap.GetInstantiatedObject(PlayerPlanningController.Instance.position);
        }
        catch { }

        if(interactable != null)
            PlanningController.Instance.AddInteraction(interactable.GetComponent<Interactable>());
        AddActionPanel(SpriteTexture);
        PlayerPlanningController.Instance.SetActionTile(interactionTile);
    }

    public void WaitButton()
    {
        PlanningController.Instance.AddWait();
        AddActionPanel(waitTexture);
        PlayerPlanningController.Instance.SetActionTile(waitingTile);
    }

    public void UndoButton()
    {
        PlanningController.Instance.UndoAction();
        if (actionQueuePanel.transform.childCount > 0)
        {
            Destroy(actionQueuePanel.transform.GetChild(actionQueuePanel.transform.childCount - 1).gameObject);
        }
        if (actionQueuePanel.transform.childCount > 1)
        {
            Destroy(actionQueuePanel.transform.GetChild(actionQueuePanel.transform.childCount - 2).gameObject);
        }
    }

    public void NextButton()
    {
        AddActionPanel(null);
    }

    public void AddActionPanel(Texture2D texture)
    {
        if (actionQueuePanel.transform.childCount >= 17)
        {
            Destroy(actionQueuePanel.transform.GetChild(0).gameObject);
            Destroy(actionQueuePanel.transform.GetChild(1).gameObject);
        }
       if(actionQueuePanel.transform.childCount > 0)
        {
            GameObject transition = Instantiate(signPrefab);
            transition.GetComponent<RawImage>().texture = transitionTexture;
            transition.transform.SetParent(actionQueuePanel.transform);
        }
        GameObject sign = Instantiate(signPrefab);
        sign.GetComponent<RawImage>().texture = texture;
        sign.transform.SetParent(actionQueuePanel.transform);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PlayerPlanningController.Instance.isUsingUI = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayerPlanningController.Instance.isUsingUI = true;
    }
}
