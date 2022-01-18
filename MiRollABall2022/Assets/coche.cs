using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coche : MonoBehaviour
{
    // Este script es otra forma de mover la bola siguiendo el v�deo del curso cefire
    float velocidadAvance = 2.0f; // 2 m/s
    float velocidadRotac = 180.0f; // 180 grados por segundo
    [SerializeField] float xInicial;
    [SerializeField] float zInicial;
    [SerializeField] int vidas;
    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        zInicial = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        // Para coger el avance con las flechas adelante y atr�s
        float avance = Input.GetAxis("Vertical")
                       * velocidadAvance * Time.deltaTime;
        // La rotaci�n con las flechas izq y dcha.
        float rotacion = Input.GetAxis("Horizontal")
                         * velocidadRotac * Time.deltaTime;
        transform.Translate(Vector3.forward * avance);
        transform.Rotate(Vector3.up * rotacion);
    }

}
