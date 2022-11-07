using System;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    public PanelController panel;
    
    [SerializeField] private TMP_Text timeAttempt;
    [SerializeField] private TMP_Text countAttempt;

    private void Awake()
    {
        if (!panel) panel = GetComponent<PanelController>();
    }

    public void SetData(int time, int count)
    {
        timeAttempt.text = "Duration of an attempt " + time + " seconds.";
        countAttempt.text = "Total attempts " + count + " times.";
    }
}
