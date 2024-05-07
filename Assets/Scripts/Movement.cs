using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isGrounded = false;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask isGround;
    const float checkRadius = 0.2f;

    private Rigidbody2D rigid;
    [SerializeField] private float jumpForce = 6.0f;

    [Header("Movement")]
    [SerializeField] private float speed = 6.0f;
    private Vector2 refVelocity = Vector2.zero;
    [Range(0, 0.3f)][SerializeField] private float smoothing = 0.05f;
    private bool faceLeft = false;
    private SpriteRenderer sprite;
    AudioSource isJumpingSound;

    

    public void Move(float move, bool jump) //variables for char actions*
    {
        Jumping(jump);
        CharMovements(move);
        CheckOrientation(move);
    }

    void CheckOrientation(float move)
    {
        if ((move > 0 && faceLeft) || (move < 0 && !faceLeft))
        {
            faceLeft = !faceLeft;
            sprite.flipX = faceLeft;
        }
    }

    private void FixedUpdate()
    {
        VerifyGround();
    }

    void VerifyGround() //used to verify if the char is grounded*
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkRadius, isGround);
        isGrounded = (collider != null) ? true : false;
    }

    void CharMovements(float move) //give force to move char
    {
        Vector2 targetVelocity = new Vector2(move * speed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, smoothing);
    }

    void Jumping(bool jump)
    {
        
        if (jump && isGrounded)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumpingSound.Play();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = (isGrounded) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundChecker.position, checkRadius);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isJumpingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
