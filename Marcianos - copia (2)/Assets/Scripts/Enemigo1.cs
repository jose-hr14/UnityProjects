using System.Collections;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    [SerializeField] float velocidadY = -1;
    [SerializeField] float velocidadDisparo = -2;
    [SerializeField] Transform prefabDisparoEnemigo;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] UnityEngine.UI.Text textoPartidaPerdida;    
    void Start()
    {
        StartCoroutine(Disparar());
    }

    IEnumerator Disparar()
    {
        float pausa = Random.Range(1.0f, 6.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparoEnemigo, transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-velocidadDisparo, 0, 0);
        GetComponent<AudioSource>().Play();

        StartCoroutine(Disparar());
    }
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
