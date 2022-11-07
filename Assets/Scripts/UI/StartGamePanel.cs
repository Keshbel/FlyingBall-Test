using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGamePanel : MonoBehaviour
{
    public PanelController panel;
    
    public List<Toggle> togglesHardMode;

    private void Awake()
    {
        if (!panel) panel = GetComponent<PanelController>();
    }
    
    private void Start()
    {
        for (var index = 0; index < togglesHardMode.Count; index++)
        {
            var index1 = index;
            togglesHardMode[index].onValueChanged.AddListener(p => GameManager.Instance.ChangeHardMode(index1+1));
        }
    }
}
