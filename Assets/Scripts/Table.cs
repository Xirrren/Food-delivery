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
                        OrderingController.instance.CompleteDelivery(other.gameObject);
                    }else
                    {
                        Debug.Log("送錯餐");
                    }
                }
            }
        }
    }

    public void DiningEffect()
    {
        StartCoroutine(Act("dining",5f));
    }
    private IEnumerator Act(string tag,float duration)
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("dining"))
            {
                ParticleSystem ps = child.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                }
                StartCoroutine(DeactivateAfterTime(ps,duration));
            }
        }
        yield return null;
    }

    IEnumerator DeactivateAfterTime(ParticleSystem ps, float duration)
    {
        yield return new WaitForSeconds(duration);
        ps.Stop();
    }

}
