using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed;
    private Vector2 movement;
    private Rigidbody2D _rb2d;
    public GameObject cycleManager;
    public CycleScript cyc;

    private void Awake()
    {
        MovementSpeed = 5F;
        _rb2d = GetComponent<Rigidbody2D>();

        cycleManager = GameObject.Find("CycleManager");
        cyc = cycleManager.GetComponent<CycleScript>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private int isGameOn()
    {
        if (cyc.stopGame)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    private void FixedUpdate()
    {
        int movementValue = isGameOn();

        _rb2d.MovePosition(_rb2d.position + movement * MovementSpeed * Time.fixedDeltaTime * movementValue);
        
        if(movement.y < 0 && movement.x != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180 * movement.x);
        }
        else if(movement.y < 0 && movement.x == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180 * movement.y);
        }
        else if (movement.x != 0 && movement.y >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90 * movement.x);  
        }
        else if (movement.x == 0 && movement.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90 * movement.x);
        }

    }
}
