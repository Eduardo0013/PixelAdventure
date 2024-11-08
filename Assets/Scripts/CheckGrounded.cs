using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public static bool isGrounded = true;
    public void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tilemap"))
        {
            isGrounded = true;
        }
    }
}
