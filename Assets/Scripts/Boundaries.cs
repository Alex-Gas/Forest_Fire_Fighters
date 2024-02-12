using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2 -2;
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2 - 1;
    }

    void LateUpdate()
    {
        Vector3 ViewPos = transform.position;
        ViewPos.x = Mathf.Clamp(ViewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x - objectWidth);
        ViewPos.y = Mathf.Clamp(ViewPos.y, screenBounds.y * -1 - objectHeight, screenBounds.y - objectHeight);
        transform.position = ViewPos;
    }
}
