using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX, movementY;

    [SerializeField] GameObject gameEnd;
    [SerializeField] TextMeshProUGUI score;
    public bool isGame = true;
    public int scoreInt = 0;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("IncreaseScore", 0.5f, 1);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {

        score.SetText("Score: " + scoreInt);
    }

    void FixedUpdate()
    {
        if (isGame)
        {
            Vector2 movement = new Vector2(movementX, movementY);
            transform.Translate(movement * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameEnd.gameObject.SetActive(true);
            isGame = false;
            CancelInvoke("IncreaseScore");
        }
    }

    public void IncreaseScore()
    {
        scoreInt++;
    }
}
