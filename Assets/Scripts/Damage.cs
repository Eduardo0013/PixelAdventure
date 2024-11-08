using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Player.lifes == 0)
        {
            Destroy(Player.rigidbody2D);
            Destroy(Player.spriteRenderer);
            SceneManager.LoadScene("SampleScene");
            Player.lifes = 3;
        }
        if (collision.CompareTag("Player"))
        {
            Player.animator.SetBool("wasHit",true);
            --Player.lifes;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        Player.animator.SetBool("wasHit",false);
    }
}
