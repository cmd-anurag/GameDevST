using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject restartButton;

    public static GameManager gameManagerInstance;

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
    }

    public void GameOverScreen(bool hasWon)
    {
        if (hasWon)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
