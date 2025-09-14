using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Table : MonoBehaviour
{
    public static Table instance;

    private bool isTarget= false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("ordering"))
                {
                    bool isVisible = child.gameObject.activeInHierarchy;
                    SpriteRenderer sr = child.GetComponent<SpriteRenderer>();

                    if (sr != null)
                    {
                        isVisible = sr.enabled && child.gameObject.activeInHierarchy;
                    }

                    if (isVisible)
                    {
                        OrderingController.instance.CompleteDelivery();
                    }else
                    {
                        Debug.Log("送錯餐");
                    }
                }
            }
        }
    }

}
