using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float speed;
    public float jumpPower;
    bool isGrounded;


    private float dirH;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.01f, 1.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        dirH = Input.GetAxis("Horizontal"); //esquerda = -1 direita = 1  nenhum = 0

        rb.velocity = new Vector2(speed * dirH, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpPower);
        }

       
        
    }



}   
