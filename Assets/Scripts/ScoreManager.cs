using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    public static ScoreManager scoreManagerInstance;
    private int _score = 0;

    private void Awake()
    {
        if (scoreManagerInstance == null)
        {
            scoreManagerInstance = this;
        }
    }
    public void AddScore(int inc)
    {
        _score += inc;
        _scoreText.text = _score.ToString();
    }
}
