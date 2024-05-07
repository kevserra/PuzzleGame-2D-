using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool isAlreadyScored; //to check if player already entered collider and scored

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isAlreadyScored)
        {
            scoreManager.ScorePoints(100);
            isAlreadyScored = true; //if true, points won't be added
        }
    }
}
