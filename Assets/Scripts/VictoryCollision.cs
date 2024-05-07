using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryCollision : MonoBehaviour
{
    private LevelManager levelManager;
    [SerializeField] private Text victoryTxt;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        victoryTxt.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            victoryTxt.enabled = true;
            if(levelManager.currentLevel == 1)     //check if on level 1
            {
                Invoke("LoadLevel2", 2f); //load the 2nd scene
            }
            else if(levelManager.currentLevel == 2) //check if on lvl 2
            {
                Invoke("LoadLevel1", 2f); //
            }
        }
    }

    private void LoadLevel1()
    {
        levelManager.LoadLevelOne();
    }

    private void LoadLevel2()
    {
        levelManager.LoadLevelTwo();
    }

    private void LoadGameOver()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
