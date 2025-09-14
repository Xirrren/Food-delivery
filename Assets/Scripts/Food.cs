using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Food instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int layers = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.transform);
            
            transform.localPosition = Vector3.zero;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sortingOrder = layers;
            }
        }
    }

    public void ConfirmIdentity(GameObject deliveredFood)
    {
        if (deliveredFood.transform.parent != null)
        {
            string parentName = deliveredFood.transform.parent.name;

            if (parentName == "Player_1"){
                Debug.Log("P1送餐完成");
                GameScore.instance.AddP1Score();
            }

            if (parentName == "Player_2")
            {
                Debug.Log("P2送餐完成");
                GameScore.instance.AddP2Score();
            }
        }
    }
}
