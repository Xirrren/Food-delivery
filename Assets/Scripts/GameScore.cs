using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;

    public TMP_Text p1ScoreTxt,p2ScoreTxt;
    
    int p1Score = 0,p2Score = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddP1Score()
    {
        p1Score++;
        UpdateScoreUI();
    }
    
    public void AddP2Score()
    {
        p2Score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        p1ScoreTxt.text = p1Score.ToString();
        p2ScoreTxt.text = p2Score.ToString();
    }

}
