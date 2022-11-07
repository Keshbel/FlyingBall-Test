using DG.Tweening;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public CanvasGroup darknessGroup;
    public GameObject panel;

    public void Open()
    {
        var value = 1f;
        var duration = 1f;
        
        darknessGroup.DOFade(value, duration);
        darknessGroup.interactable = true;
        darknessGroup.blocksRaycasts = true;
        panel.transform.DOScale(value, duration);
    }
    
    public void Close()
    {
        var value = 0f;
        var duration = 1f;
        
        darknessGroup.DOFade(value, duration);
        darknessGroup.interactable = false;
        darknessGroup.blocksRaycasts = false;
        panel.transform.DOScale(value, duration);
    }
}
