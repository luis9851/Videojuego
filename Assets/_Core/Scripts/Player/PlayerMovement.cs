using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public FloatingJoystick joystick;
    public Rigidbody2D rigidbody2D;

    private float horizontalVal;
    public float speed;
    public float jumpForce;
    
    public Animator animator;
    public SpriteRenderer spriteRender;
    private bool  facingRight = true;
    public GroundCheck groundCheck;
    private bool blockMovement = false;
    bool isGrounded = true;

    public void BlockMovement(bool _block){
        blockMovement = _block;
    }

    public void StopMovement(){
        rigidbody2D.velocity = Vector2.zero;
    }

    public void DamageForce(){
        if(facingRight){
            rigidbody2D.AddForce(new Vector2(-50, 250));
        }else{
            rigidbody2D.AddForce(new Vector2(50, 250));
        }
        
    }

    void Update()
    {
        // Debug.Log("Player Movement - Update");
        if(blockMovement){ return; }
        Move();
        Jump();
        Flip();

        animator.SetFloat("Speed", Mathf.Abs(horizontalVal));
    }

    private void Jump()
    {
        if(!groundCheck.isGrounded){return;}

        if (Input.GetKeyDown(KeyCode.Space)){
            /* Debug.Log("SALTA!!!!!"); */
            animator.SetBool("Is_Jumping",true);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    public void DoJump(){
        if(!groundCheck.isGrounded){return;}
        animator.SetBool("Is_Jumping",true);
        isGrounded = false;
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
    }
    public void OnJumpClick(){
        DoJump();
    }

    public void OnLandEvent(){
        animator.SetBool("Is_Jumping",false);
    }

    private void Move()
    {
        
        ////PC
        horizontalVal = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontalVal * speed, rigidbody2D.velocity.y);
        ///Movil
        /* horizontalVal = joystick.Horizontal;
        float moveBy = horizontalVal * speed;
        rigidbody2D.velocity = new Vector2(moveBy * speed, rigidbody2D.velocity.y); */
    }

    private void Flip(){
        if((horizontalVal<0 && facingRight)||(horizontalVal>0 && !facingRight)){
            facingRight =! facingRight; 
            /* spriteRender.flipX = !facingRight; */
            transform.Rotate(0,180,0);
        }

    }

}
