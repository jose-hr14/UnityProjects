using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;
    [SerializeField] float velocidad;
    private byte siguientePosicion;
    private GameController gameController;
    [SerializeField] private float distanciaCambio;
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        siguientePosicion = 0;

    }

    // Update is called once per frame
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
