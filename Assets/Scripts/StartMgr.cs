using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMgr : MonoBehaviour
{
    public GameObject setScreen,tutorialScreen;
    public Button startBtn,setBtn,quitBtn;

    [Header("SetScreen")]
    public Button okBtn;
    [Header("新手教學tutorial")]
    public Button yesBtn,noBtn;

    void CloseScreen()
    {
        setScreen.SetActive(false);
        tutorialScreen.SetActive(false);
    }
    void Start()
    {
        CloseScreen();
        setBtn.onClick.AddListener(delegate { setScreen.SetActive(true); });
        startBtn.onClick.AddListener(delegate { tutorialScreen.SetActive(true); });
        quitBtn.onClick.AddListener(delegate { Application.Quit(); });
        
        okBtn.onClick.AddListener(delegate { CloseScreen(); });
        
        yesBtn.onClick.AddListener(delegate { SceneManager.LoadScene("GameScene"); });
        noBtn.onClick.AddListener(delegate { SceneManager.LoadScene("GameScene"); });
    }

}
