using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CycleScript : MonoBehaviour
{
    public GameObject health;
    public HealthBar healthBar;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    bool shouldRunF1;
    public bool stopGame;

    void Start()
    {
        shouldRunF1 = false;
        stopGame = false;
        health = GameObject.Find("Health Bar");
        healthBar = health.GetComponent<HealthBar>();

        StartCoroutine(DelayEndCheck());
    }

    void Update()
    {
        if (shouldRunF1 && stopGame == false)
        {
            IsEnd();
        }
    }

    IEnumerator DelayEndCheck()
    {
        yield return new WaitForSeconds(2f);
        shouldRunF1 = true;
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator DelayReload()
    {
        yield return new WaitForSeconds(4f);
        Reload();
    }

    void IsEnd()
    {
        if (healthBar._slider.value >= healthBar.maxHealth)
        {
            EndGame("loss");
        }


        else if (healthBar._slider.value <= 0)
        {
            EndGame("win");
        }
    }



    public void EndGame(string outcome)
    {
        switch (outcome)
        {
            case "win":
                victoryScreen.SetActive(true);
                stopGame = true;
                StartCoroutine(DelayReload());
                break;

            case "loss":
                gameOverScreen.SetActive(true);
                stopGame = true;
                StartCoroutine(DelayReload());
                break;
        }
    }

}
