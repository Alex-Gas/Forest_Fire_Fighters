using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireBall : MonoBehaviour
{
    public GameObject Object2Spawn;
    public Vector3 NewPosX;
    public Vector3 NewPosY;
    public float Offset;
    public float RandNum;

    private void Awake()
    {
        Offset = 1F;
        RandNum = 0F;
        NewPosX.x = transform.position.x + Offset;
        NewPosX.y = transform.position.y;
        NewPosY.x = transform.position.x;
        NewPosY.y = transform.position.y + Offset;
    }

    public void MakeFireAfter()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        Offset = Random.Range(-1, 2);
        if (Offset == 0)
        {
            Offset = 1;
        }
        RandNum = Random.Range(1, 3);
        yield return new WaitForSeconds(1);
        if (RandNum == 1)
        {
            SpawnFireX();
        }
        if (RandNum == 2)
        {
            SpawnFireY();
        }

    }

    public void SpawnFireX()
    {
        Instantiate(Object2Spawn, NewPosX, transform.rotation);
    }
    public void SpawnFireY()
    {
        Instantiate(Object2Spawn, NewPosY, transform.rotation);
    }
}
