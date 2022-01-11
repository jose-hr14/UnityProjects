using System.Collections;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    [SerializeField] float velocidadY = -1;
    [SerializeField] float velocidadDisparo = -2;
    [SerializeField] Transform prefabDisparoEnemigo;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] UnityEngine.UI.Text textoPartidaPerdida;
    //Cuando se instancie la nave enemiga al iniciar la escena, llamará a la corrutina disparar.
    void Start()
    {
        StartCoroutine(Disparar());
    }
    //Esta corrutina deja una espera aleatoria de entre 1 y 6 segundos entre disparo y disparo.
    //Finalizada la espera, la nave instancia un disparo enemigo, y le asigna una velocidad para
    //que este se desplace hacia la derecha, además de hacer sonar el sonido del disparo.
    IEnumerator Disparar()
    {
        float pausa = Random.Range(1.0f, 6.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparoEnemigo, transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-velocidadDisparo, 0, 0);
        GetComponent<AudioSource>().Play();

        StartCoroutine(Disparar());
    }
    //Ejecutado por cada frame, hace que la nave se desplace hacia abajo hasta llegar al límite de la pantalla.
    //Al tocar el límite, se desplazará ligeramente hacia la derecha y subirá. Así sucesivamente.
    void Update()
    {        
        transform.Translate(0, velocidadY * Time.deltaTime, 0);
            
        if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
        {
            velocidadY = -velocidadY;
            transform.Translate(0.5f, velocidadY * Time.deltaTime, 0);
        }
        if (transform.position.x > 5)
            Destroy(gameObject);
    }
}
