using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private Player player;
    [SerializeField] private LayerMask layerGround;

    private bool CanDetected;

    private void Update()
    {
        if(CanDetected)
        {
            player.ledgeDetected = Physics2D.OverlapCircle(transform.position, radius, layerGround);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            CanDetected = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            CanDetected = true;
        }
    }
}
