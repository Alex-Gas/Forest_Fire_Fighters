using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCounter : MonoBehaviour
{
    public int TotalFires;
    public int CurrentNumOfFires;
    private GameObject FireBalls;

    void Start()
    {
        TotalFires = 0;
        CurrentNumOfFires = 0;
        FireBalls = GameObject.Find("Fire Ball Container");
    }

    void Update()
    {
        CurrentNumOfFires = FireBalls.transform.childCount;
    }
}
