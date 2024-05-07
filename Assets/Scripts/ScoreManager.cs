using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    [SerializeField] private Text scoreText;
    
    public void ScorePoints(int amount)
    {
        currentScore += amount;
        scoreText.text = $"SCORE: {currentScore}";
    }
}
