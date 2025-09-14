using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Settlement : MonoBehaviour
{
    public static Settlement instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public GameObject p1Win, p2Win;
    public TMP_Text P1Txt, p2Txt;
    public TMP_Text P1Txt2, p2Txt2;
    private int p1Score = 0,p2Score = 0;

    public void ScoreSettlement()
    {
        p1Score = GameScore.instance.p1Score;
        p2Score = GameScore.instance.p2Score;

        if (p1Score > p2Score)
        {
            p1Win.SetActive(true);
            AudioMgr.Instance.PlaySFX(AudioMgr.SFXType.Win);
        }else if (p1Score < p2Score)
        {
            p2Win.SetActive(true);
            AudioMgr.Instance.PlaySFX(AudioMgr.SFXType.Win);
        }
        P1Txt.text = p1Score.ToString();
        P1Txt2.text = p1Score.ToString();
        p2Txt.text = p2Score.ToString();
        p2Txt2.text = p2Score.ToString();
    }
    
}
