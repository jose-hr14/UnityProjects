using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    // Cuando el collider de la salida entre en contacto con el rigid body del
    // jugador, se llamará a la corutina salida
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Salir");
        }
    }

    // Se ralentiza el tiempo durante unos 3 segundos, se reproduce el efecto sonoro de salir del nivel,
    // se devuelve el tiempo a la normalidad, si se llama a la función de avanzar nivel del game controller
    private IEnumerator Salir()
    {
        Time.timeScale = 0.1f;
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, gameObject.transform.position);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        FindObjectOfType<GameController>().AvanzarNivel();
    }
}