using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSelect : MonoBehaviour
{
    [System.Serializable]
    public struct PanelInfo
    {
        public GameObject panel;
        public Button button;
        public KeyCode key;
    }

    public KeyCode toggle;
    public GameObject panel;
    public PanelInfo[] panelInfos;

    void Start()
    {
        foreach (PanelInfo panelInfo in panelInfos)
        {
            panelInfo.button.onClick.AddListener(delegate { ButtonEvent(panelInfo); });
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggle))
        {
            panel.SetActive(!panel.activeSelf);
        }

        foreach(PanelInfo panelInfo in panelInfos)
        {
            if (Input.GetKeyDown(panelInfo.key))
            {
                SetPanelActive(panelInfo);
            }
        }
    }

    void SetPanelActive(PanelInfo panelInfo)
    {
        for(int i = 0; i < panelInfos.Length; i++)
        {
            bool active = panelInfos[i].Equals(panelInfo);
            panelInfos[i].panel.SetActive(active);
        }
    }

    void ButtonEvent(PanelInfo panelInfo)
    {
        SetPanelActive(panelInfo);
    }
}
