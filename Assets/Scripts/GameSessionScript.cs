using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessionScript : MonoBehaviour
{
    [SerializeField] int playerLives;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI livesTextMeshProUGUI;
    [SerializeField] TextMeshProUGUI scoresTextMeshProUGUI;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSessionScript>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesTextMeshProUGUI.text = "" + playerLives;
        scoresTextMeshProUGUI.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1 )
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesTextMeshProUGUI.text = "" + playerLives;
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersistScript>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoresTextMeshProUGUI.text = score.ToString();
    }
}
