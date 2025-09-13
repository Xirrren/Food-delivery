using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MealDeliveryControl : MonoBehaviour
{
    public static MealDeliveryControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public GameObject food;
    
    public Transform foodOutletA,foodOutletB;
    
    private bool hasSpawned = false;
    
    private GameObject currentFood;

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

    public void SpawnFood()
    {
        Transform target = Random.value > 0.5f ? foodOutletA : foodOutletB;
        
        currentFood = Instantiate(food,target.position,target.rotation);
        
        Debug.Log("Food生成於" + target.name);
    }
    
    public void DestroyFood()
    {
        if (currentFood != null)
        {
            Destroy(currentFood);
            currentFood = null;
            hasSpawned = false;
        }
    }
}
