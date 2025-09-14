using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class OrderingController : MonoBehaviour
{
    public static OrderingController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public List<GameObject> table;
    public string ordering;
    
    public float orderCooling = 5f;

    private GameObject currentChild;
    private Dictionary<GameObject,float> cooldowns = new Dictionary<GameObject, float>();

    void Start()
    {
        StartCoroutine(showRandomChild());
    }

    IEnumerator showRandomChild()
    {
        while (true)
        {
            GameObject randomObj = GetRandowAvailableObject();
            
            if (randomObj != null)
            {
                currentChild = randomObj.transform.Find(ordering)?.gameObject;

                if (currentChild != null)
                {
                    currentChild.SetActive(true);

                    while (currentChild.activeInHierarchy)
                    {
                        yield return null;
                    }
                }

                yield return null;
            }
        }

        GameObject GetRandowAvailableObject()
        {
            List<GameObject> availableObjects = new List<GameObject>();
            foreach (var obj in table)
            {
                if (!cooldowns.ContainsKey(obj) || Time.time > cooldowns[obj])
                {
                    availableObjects.Add(obj);
                }
            }

            if (availableObjects.Count == 0) return null;
            return availableObjects[Random.Range(0, availableObjects.Count)];
        }
    }

    public void CompleteDelivery(GameObject deliveredFood)
    {
        Food.instance.ConfirmIdentity(deliveredFood);
        currentChild.SetActive(false);
        MealDeliveryControl.instance.DestroyFood();
        cooldowns[currentChild.transform.parent.gameObject] = Time.time + orderCooling;
        StartCoroutine(showRandomChild());
    }
}
