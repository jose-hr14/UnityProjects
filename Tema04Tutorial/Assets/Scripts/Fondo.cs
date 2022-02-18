using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    // Si el collider del fondo, el cual se encontará en la parte inferior del mismo colisiona con el rigid body del
    // jugador, se llamará a la función de perder vida del game controller.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            FindObjectOfType<GameController>().PerderVida();
    }
}