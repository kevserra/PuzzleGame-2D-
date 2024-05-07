using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{
    private GameManager gameManager;

    public void OnCollisionEnter2D(Collision2D touchSpikes)
    {
        if (touchSpikes.collider.CompareTag("DEATH"))
        {
            Death();
        }
    }

    void Death()
    {
        //Destroy(gameObject);
        gameManager.LoseLife();
    }

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    gameObject.SetActive(true);
        //}
    }
}
