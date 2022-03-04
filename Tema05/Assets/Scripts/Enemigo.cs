using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    public Transform particulasChoque;
    private int vidas;
    Vector3 siguientePosicion;
    byte numeroSiguientePosicion;
    float distanciaCambio = 0.2f;
    float velocidad = 2;
    [SerializeField] private AudioClip audioSource;
    void Start()
    {
        if(wayPoints.Length > 0)
            siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
        vidas = 3;
    }
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, FindObjectOfType<Jugador>().transform.position) < 10)
        {
            GetComponent<NavMeshAgent>().SetDestination(FindObjectOfType<Jugador>().transform.position);
        }
        else if (wayPoints.Length > 0)
        {
            transform.LookAt(siguientePosicion);
            transform.position = Vector3.MoveTowards(transform.position,
                siguientePosicion,
                velocidad * Time.deltaTime);
            if (Vector3.Distance(transform.position, siguientePosicion) <
                distanciaCambio)
            {
                numeroSiguientePosicion++;
                if (numeroSiguientePosicion >= wayPoints.Length)
                    numeroSiguientePosicion = 0;
                siguientePosicion = wayPoints[numeroSiguientePosicion].position;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Jugador>().PerderVida();
            FindObjectOfType<GameStatus>().vidas--;
        }
    }

    public void QuitarVida()
    {
        vidas--;
        if (vidas < 1)
        {
            AudioSource.PlayClipAtPoint(audioSource, transform.position);
            FindObjectOfType<GameController>().AnotarEnemigoDerrotado();
            Transform particulasParedInstanciadas = Instantiate(particulasChoque, gameObject.transform.position, Quaternion.identity);
            Destroy(particulasParedInstanciadas.gameObject, 3);
            Destroy(gameObject);
        }
    }
}
