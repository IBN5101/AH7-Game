using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private PlayerController player;
    public static bool gameProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameProgress = true;
        player.InvokeRepeating("IncreaseScore", 0.5f, 1);
    }
}
