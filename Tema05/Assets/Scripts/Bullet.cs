using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bullet ");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.SendMessage("QuitarVida");
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
