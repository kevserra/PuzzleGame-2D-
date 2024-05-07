using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public string levelToLoad;
    public int currentLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene");
        currentLevel =  1;
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level 2");
        currentLevel = 2;            
    }
}
