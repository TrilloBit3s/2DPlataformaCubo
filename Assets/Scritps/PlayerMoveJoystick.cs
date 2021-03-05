// Scrip para Mobile
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{  
    public float speed;
    public float jumpForce; 
    private Rigidbody2D rb;
    private bool facingRight = true;

    //variaveis para joystick
    private float horizontalMove = 0f;
    public Joystick joystick;
    public float runSpeedHorizontal = 2;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FixedUpdate();      
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0 , 0) * Time.deltaTime * speed;
        
        if(facingRight == false && horizontalMove > 0)
        {   
            Flip();
        }else if(facingRight == true && horizontalMove < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Jump()
    {
        if(rb.velocity.y == 0)
        {
          // rb.velocity = Vector2.up * jumpForce;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    } 
}