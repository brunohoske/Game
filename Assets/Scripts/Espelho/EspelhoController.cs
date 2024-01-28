using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EspelhoController : MonoBehaviour
{
    public SceneAsset destino;
    public LayerMask playerLayer;

    private bool playerHit;

    void Start()
    {
        playerHit = true;
    }

    void Update()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1f, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit=false;
        }

        if (Input.GetKeyDown(KeyCode.E) && playerHit == true)
        {
            SceneManager.LoadScene(destino.name);
        }
    }
}
