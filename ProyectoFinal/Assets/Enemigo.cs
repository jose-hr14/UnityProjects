using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    private int vidas;
    Vector3 siguientePosicion;
    byte numeroSiguientePosicion;
    float distanciaCambio = 0.2f;
    float velocidad = 2;
    void Start()
    {
        if(wayPoints.Length > 0)
            siguientePosicion = wayPoints[0].position;
        numeroSiguientePosicion = 0;
        vidas = 3;
    }
    void Update()
    {
        if (wayPoints.Length > 0)
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

    public void QuitarVida()
    {
        vidas--;
        if (vidas < 1)
        {
            FindObjectOfType<GameController>().AnotarEnemigoDerrotado();
            Destroy(gameObject);
        }
    }
}
