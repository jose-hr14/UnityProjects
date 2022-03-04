using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // Utilizamos la cámara para el RayCast
    [SerializeField] Camera camara;
    [SerializeField] private int vidas;
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Disparando...");
            float distanciaMaxima = 50;
            RaycastHit hit;
            bool impactado = Physics.Raycast(camara.transform.position,
                w, out hit, distanciaMaxima);
            if (impactado)
            {
                Debug.Log("Disparo impactado");
                if (hit.collider.CompareTag("Enemigo"))
                {
                    Debug.Log("Enemigo acertado");
                    hit.collider.gameObject.SendMessage("QuitarVida");
                }
            }
        }*/
    }

    public void PerderVida()
    {
        vidas--;
        if (vidas < 0)
        {
            StartCoroutine(FindObjectOfType<GameController>().GameOver());
        }
    }

    public int GetVidas()
    {
        return vidas;
    }

}