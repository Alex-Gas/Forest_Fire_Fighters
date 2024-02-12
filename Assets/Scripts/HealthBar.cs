using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.UIElements.ToolbarMenu;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    public GameObject VarCont;
    public FireCounter fireCount;
    public int maxHealth;

    private void Awake()
    {
        maxHealth = 400;
        VarCont = GameObject.Find("ContainerForVariables");
        fireCount = VarCont.GetComponent<FireCounter>();

        _slider.maxValue = maxHealth;
    }


    void Update()
    {
        int health = fireCount.CurrentNumOfFires;
        SetHealth(health);

    }


    public void SetHealth(int health)
    {
        _slider.value = health;
    }

}
