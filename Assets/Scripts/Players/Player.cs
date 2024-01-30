using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float speed;
    public float jumpPower;
    private bool isGrounded;

    private bool wallDetect ;
 
    //Variaveis para definir o gizmo do checador de parede (wall check);
    [SerializeField] private Vector2 size;
    [SerializeField] private Transform wallCheck;

    //Variavel que identificará se o player esta tocando na borda
    [HideInInspector] public bool ledgeDetected;

    //Ledge
    [Header("Ledge Info")]
    [SerializeField] private Vector2 offset1;
    [SerializeField] private Vector2 offset2;

    private Vector2 ClimbBegunPosition;
    private Vector2 ClimbOverPosition;

    private bool canGrabLedge = true;
    private bool canClimb;



    private float dirH;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
        Movement();
        CheckForLedge();

        Debug.Log(ledgeDetected);
    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.01f, 1.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);

    }
    private void Movement()
    {
        dirH = Input.GetAxis("Horizontal"); //esquerda = -1 direita = 1  nenhum = 0

        rb.velocity = new Vector2(speed * dirH, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpPower);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(wallCheck.position, size);
    }

    private void CheckForLedge()
    {
        if (ledgeDetected && canGrabLedge && Input.GetKeyDown(KeyCode.E))
        {
            canGrabLedge = false;

            Vector2 ledgePosition = GetComponentInChildren<LedgeDetection>().transform.position;

            ClimbBegunPosition = ledgePosition + offset1;
            ClimbOverPosition = ledgePosition + offset2;

            canClimb = true;
        }

        if (canClimb)
        {
            transform.position = ClimbBegunPosition;
            LedgeClimbOver(); // quando tiver a animação de escalada tire isso daqui e coloque esse metodo para rodar após o ultimo frame
                              // da animação (https://youtu.be/Kh5n63A-YBw?t=1339)
        }


    }

    private void LedgeClimbOver()
    {
        canClimb = false;
        transform.position = ClimbBegunPosition;
        Invoke("AllowLedgeGrab", .1f);
    }


    private void AllowLedgeGrab() => canGrabLedge = true;

}   
