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

    public void Eat()
    {
        Destroy(this.gameObject);
    }
}
