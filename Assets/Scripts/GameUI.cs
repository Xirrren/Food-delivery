using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject setScreen;
    public Button setButton;
    public Button okButton;

    private void Start()
    {
        setButton.onClick.AddListener(delegate { setScreen.SetActive(true); });
        okButton.onClick.AddListener(delegate { setScreen.SetActive(false); });
    }
}
