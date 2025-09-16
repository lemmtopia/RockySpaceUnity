using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton static instance variable
    public static GameController instance;

    // Score
    [SerializeField] private int score;
    [SerializeField] private int highScore;

    private void Awake()
    {
        // Be sure that I'm the only GameController that exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
