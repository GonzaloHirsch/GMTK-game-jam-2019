using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class AbilityImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    public Image tooltip;
    public Text tooltipText;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    public void Activate()
    {
        image = gameObject.GetComponent<Image>();

        tooltip.DOFade(0, 0f);
        tooltipText.DOFade(0, 0f);
    }

    public void SetImage()
    {
        image.sprite = MainPlayerController.Instance.ability.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(true);
        tooltipText.text = MainPlayerController.Instance.ability.description;

        tooltip.DOFade(1, 1f);
        tooltipText.DOFade(1, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.DOFade(0, 1f);
        tooltipText.DOFade(0, 0.2f);
        tooltip.gameObject.SetActive(false);
    }
}
