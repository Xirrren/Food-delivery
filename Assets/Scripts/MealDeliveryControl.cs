using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealDeliveryControl : MonoBehaviour
{
    public GameObject food, ordering;
    
    public Transform foodOutletA,foodOutletB;
    
    private bool hasSpawned = false;

    public Button orderBtn;
    void Start()
    {
        orderBtn.onClick.AddListener(SpawnOrdering);
    }

    void Update()
    {
        if (!hasSpawned)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("ordering");
            if (objs.Length > 0)
            {
                SpawnFood();
                hasSpawned = true;
            }
        }
    }

    void SpawnFood()
    {
        Transform target = Random.value > 0.5f ? foodOutletA : foodOutletB;
        
        Instantiate(food,target.position,target.rotation);
        
        Debug.Log("Food生成於" + target.name);
    }

    void SpawnOrdering()
    {
        ordering.SetActive(true);
    }
}
