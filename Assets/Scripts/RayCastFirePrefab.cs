using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastFirePrefab : MonoBehaviour
{
    private int delay;
    [SerializeField] private int interval;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private LayerMask fireLayer;
    [SerializeField] private GameObject fireObject;
    private GameObject FireBallContainer;
    private int time;
    private bool allowSpread;
    private Vector3 thisNodePosition;
    private Vector3 nodeSize;
    private Collider2D fireObjectCollider;

    void Start()
    {
        allowSpread = false;
        fireObjectCollider = GetComponent<Collider2D>();
        System.Random random = new System.Random();
        nodeSize = fireObjectCollider.bounds.size;
        delay = random.Next(200, 500);
        time = delay;
        thisNodePosition = this.transform.position;
        FireBallContainer = GameObject.Find("Fire Ball Container");
    }




    void Update()
    {
        time -= 1;

        if (allowSpread == true && time < 0)
        {
            time = interval;
            SpawnFire();
        }

        else if (time < 0)
        {
            allowSpread = true;
        }
    }

    void SpawnFire()
    {
        Vector3 newNodePosition = chooseNewNode();

        if (IsFire(newNodePosition) == false)
        {
            GameObject myFire = Instantiate(fireObject, newNodePosition, Quaternion.identity, FireBallContainer.transform);
        }
    }

    Vector3 chooseNewNode()
    {
        System.Random random = new System.Random();
        float x = random.Next(-1, 2) * nodeSize.x;
        float y = random.Next(-1, 2) * nodeSize.y;

        Vector3 offsetVector = new Vector3(x, y, 0);
        Vector3 chosenNewPosition = thisNodePosition + offsetVector;
        return chosenNewPosition;
    }

    bool IsFire(Vector3 newNodePosition)
    {
        if (newNodePosition.x <= width / 2 && newNodePosition.x >= -width / 2 && newNodePosition.y <= height / 2 && newNodePosition.y >= -height / 2)
        {
            RaycastHit2D rayCast = Physics2D.Raycast(newNodePosition + new Vector3(0, 0, -10), Vector3.back, 100, fireLayer);
            return rayCast.collider != null;
        }

        else return true;
    }
}
