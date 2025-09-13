using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table instance;

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
            OrderingController.instance.CompleteDelivery(other.gameObject);
        }

    }

}
