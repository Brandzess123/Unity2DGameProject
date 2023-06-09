using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //biến rigid
    private BoxCollider2D coll; //biến box collider
    private SpriteRenderer sprite; //khởi tạo biến
    private Animator anim;

    // [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private float moveSpeed = 7f;   //biến tốc độ chạy
     private float jumpForce = 14f; //biến lực nhảy

    private enum MovementState { idle, running, jumping, falling }; //lấy 4 thuộc tính

    // [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //liên kết component bên ngoài với biến khởi tạo
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);   
        // GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
        
        if (Input.GetButtonDown("Jump") ) //&& IsGrounded()
        {
            // jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // if (dirX > 0f)
        // {
        //     anim.SetBool("running", true);
        //      sprite.flipX =false;
        // }
        // else if (dirX < 0f)
        // {
        //     anim.SetBool("running",true);
        //     sprite.flipX =true;
        // }
        // else
        // {
        //     anim.SetBool("running",false);
        // }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state; 

        if (dirX > 0f) //di chuyển lên
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) //di chuyển ngược => trả false => flip
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else  //nếu không di chuyển thì đứng yên ngồi lắc
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) //di chyển lên 
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f) 
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state); //
    }

    // private bool IsGrounded()
    // {
    //     return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    // }
}
