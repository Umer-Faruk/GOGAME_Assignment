using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
 
public class bullet : MonoBehaviour
{

    public ParticleSystem eff;
    // public player pl;
    // private void Start()
    // {
    //     pl = FindObjectOfType(typeof(player)) as player;
    // }
    //
    // private void Update()
    // {
    //     if (transform.position.y < -1)
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }
    //
    //
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "p1b" || collision.gameObject.tag == "p2b")
        {
            showeff();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "ground")
        {
            showeff();
            Destroy(this.gameObject);
        }
    }

    public void showeff()
    {
        Destroy(Instantiate(eff.gameObject,transform.position,Quaternion.identity) as GameObject ,0.5f); 
    }

    //
    //     if (collision.gameObject.tag == "player1")
    //     {
    //         //player1 helth decrese
    //         // pl.p1hit();
    //         pl.p1h -= 1;
    //
    //         Destroy(this.gameObject);
    //     }
    //
    //     if (collision.gameObject.tag == "player2")
    //     {
    //         //player2 helth decrese
    //         // pl.p2hit();
    //         pl.p2h -= 1;
    //         Destroy(this.gameObject);
    //     }
    //     
    //     Destroy(this.gameObject);
    //
    // }
}
