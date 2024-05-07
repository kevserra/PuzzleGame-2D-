using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSFX : MonoBehaviour
{
    public bool isColliding;
    public AudioSource pushBox;
    public AudioSource screamPush;
    

    void OnCollisionEnter2D(Collision2D collis)
    {
        
        if (collis.gameObject.CompareTag("Player") && !isColliding)
        {
            isColliding = true;
            playSound(pushBox);
            playSound(screamPush);
        }
    }

    void OnCollisionExit2D(Collision2D collis)
    {
        isColliding = false;
        pushBox.Stop();
        screamPush.Stop();
    }
    void playSound(AudioSource boxInteract)
    {
        boxInteract.Play();
    }

    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
