using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] Text livesCountText;
    public int lives = 3;

    private static int currentLives = 3;

    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>(); //finding levelManager in the scene
        livesCountText.text = $"LIVES: {currentLives}";
    }

    // Called from death collision
    public void LoseLife()
    {
        currentLives -= 1; // eveytime this is called the player loses 1 life
        livesCountText.text = $"LIVES: {currentLives}";

        if (currentLives <= 0)
        {
            levelManager.LoadLevelOne(); //checks after every lost life to see if the lives count reached less than or = to 0*
            currentLives = lives;
        }
        else
        {
            if (levelManager.currentLevel == 1)
            {
                levelManager.LoadLevelOne();
            }
            else if(levelManager.currentLevel == 2)
            {
                levelManager.LoadLevelTwo();
            }
            
        }
    }
}
