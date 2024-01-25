using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    
    

    public Rigidbody2D rb;
    public float speed;
    public float jump;

    private float dirH;
    private float dirV;
    private bool isInPlatform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isInPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        dirH = Input.GetAxis("Horizontal"); //esquerda = -1 direita = 1  nenhum = 0
        dirV = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(speed * dirH, rb.velocity.y);

        if (isInPlatform == true) 
        {
            rb.velocity = new Vector2(speed * dirH, dirV * jump);
        }

    }



}   
