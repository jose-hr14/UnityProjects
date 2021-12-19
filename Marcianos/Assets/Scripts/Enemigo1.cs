using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    [SerializeField] float velocidadX = 0;
    [SerializeField] float velocidadY = -1;
    [SerializeField] float velocidadDisparo = -2;
    [SerializeField] Transform prefabDisparoEnemigo;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] UnityEngine.UI.Text textoPartidaPerdida;
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(0,
         velocidadY * Time.deltaTime, 0);

            
        if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
        {
            velocidadY = -velocidadY;
            velocidadX = 0.5f;
            transform.Translate(0.5f, velocidadY * Time.deltaTime, 0);
        }           
    }




}
