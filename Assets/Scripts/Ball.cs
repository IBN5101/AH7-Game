using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 movement;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomMovement", 0.5f, 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameController.gameProgress)
            transform.Translate(movement * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallW"))
            movement *= new Vector2(1, -1);
        if (collision.gameObject.CompareTag("WallH"))
            movement *= new Vector2(-1, 1);
    }

    public void RandomMovement()
    {
        movement = new Vector2(Random.Range(1, 5), Random.Range(1, 5));
        speed = Random.Range(1, 3);
    }
}
