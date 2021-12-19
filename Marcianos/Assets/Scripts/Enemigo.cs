using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] float velocidadX = 2;
    [SerializeField] float velocidadY = -1;
    [SerializeField] float velocidadDisparo = -2;
    [SerializeField] Transform prefabDisparoEnemigo;
    [SerializeField] Transform prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
    }

    IEnumerator Disparar()
    {
        float pausa = Random.Range(5.0f, 11.0f);
        yield return new WaitForSeconds(pausa);
        Transform disparo = Instantiate(prefabDisparoEnemigo, transform.position, Quaternion.identity);
        disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);

        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime,
         velocidadY * Time.deltaTime, 0);
        if ((transform.position.x < -4) || (transform.position.x > 4))
            velocidadX = -velocidadX;
        if ((transform.position.y < -2.5) || (transform.position.y > 2.5))
            velocidadY = -velocidadY;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }
        
    }


}
