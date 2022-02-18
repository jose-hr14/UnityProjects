using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] public float velocidad;
    private byte siguientePosicion;
    [SerializeField] private float distanciaCambio;
    [SerializeField] public AudioClip audioClip;

    // En el update programamos a los enemigos para que se muevan hacia los distintos waypoints del warray, y cuando
    // llegue al último, volverá a desplazarse hacia al primero.
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            wayPoints[siguientePosicion].transform.position,
            velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position,
                wayPoints[siguientePosicion].transform.position) < distanciaCambio)
        {
            siguientePosicion++;
            if (siguientePosicion >= wayPoints.Count)
                siguientePosicion = 0;
        }
    }
}