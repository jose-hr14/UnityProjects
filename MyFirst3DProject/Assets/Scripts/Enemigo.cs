using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    Vector3 siguientePosicion;
    [SerializeField] float velocidad = 2;
    float distanciaCambio = 0.2f;
    int numeroSiguientePosicion = 0;
    void Start()
    {
        siguientePosicion = wayPoints[0].position;

    }
    void Update()
    {
        // Nos movemos hacia la siguiente posición
        transform.position = Vector3.MoveTowards(transform.position,
        siguientePosicion,
       velocidad * Time.deltaTime);
        // Si la distancia al punto es corta cambiamos al siguiente
        if (Vector3.Distance(transform.position,
        siguientePosicion) < distanciaCambio)
        {
            numeroSiguientePosicion++;
            if (numeroSiguientePosicion >= wayPoints.Length)
                numeroSiguientePosicion = 0;
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("PerderVida");
    }

}
