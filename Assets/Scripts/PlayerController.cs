using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX, movementY;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        //rb.AddForce(movement * speed);
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
