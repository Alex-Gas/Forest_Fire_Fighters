using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    private SpriteRenderer SprtRen;
    private BoxCollider2D Box2D;
    private Collider2D CircleCollider;
    public float RandNum;
    public bool FireActive;
    private GameObject FireBallContainer;
    public static int numberOfSpawners;

    private void Start()
    {
        FireActive = false;
        RandNum = 0F;
        CircleCollider = GetComponent<Collider2D>();
        SprtRen = GetComponent<SpriteRenderer>();
        SprtRen.enabled = false;
        CircleCollider.enabled = false;
        RandNum = Random.Range(1, 3);
        FireBallContainer = GameObject.Find("Fire Ball Container");
        numberOfSpawners = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfSpawners < 5)
        {
            if (RandNum == 1)
            {
                FireActive = true;
                SprtRen.enabled = true;
                CircleCollider.enabled = true;
                this.transform.SetParent(FireBallContainer.transform);
                numberOfSpawners += 1;
            }
            else if (RandNum != 1)
            {
                RandNum = Random.Range(1, 3);
            }
        }
    }
}
