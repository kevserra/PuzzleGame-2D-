using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platformer2DUserControls : MonoBehaviour
{
    private Animator anima;

    private bool jump = false;
    private float horizMove = 0;
    private Movement playerChar;



    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        playerChar = GetComponent<Movement>();
    }

    public void OnMove(InputAction.CallbackContext cntxt)
    {
        Vector2 move = cntxt.ReadValue<Vector2>();
        horizMove = move.x;
    }

    public void OnJump(InputAction.CallbackContext cntxt)
    {
        jump = cntxt.performed;
    }

    // Update is called once per frame
    void Update()
    {
        anima.SetFloat("horizMove", Mathf.Abs(horizMove));
    }

    private void FixedUpdate()
    {
        playerChar.Move(horizMove, jump);
        jump = false;
    }
}
