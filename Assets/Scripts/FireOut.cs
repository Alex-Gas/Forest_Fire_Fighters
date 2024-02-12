using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOut : MonoBehaviour
{
    public GameObject Fire;
    [HideInInspector] public GameObject health;
    [HideInInspector] public FireCounter fireCount;

    void Awake()
    {
        health = GameObject.Find("ContainerForVariables");
        fireCount = health.GetComponent<FireCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
