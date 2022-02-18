using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidad = 5;
    [SerializeField] float velocidadSalto = 20;
    private Animator animator;

    private float xInicial, yInicial;

    private Rigidbody2D rb;

    private float alturaPersonaje;

    // Al cargarse la escena, recogemos en variables el rigid body, la posicion inicial, la altura del personaje,
    // la animación 2d, el game controller y el sprite renderer
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        animator = gameObject.GetComponent<Animator>();
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Aquí programamos el movimiento del personaje, que mire a izquierda o derecha según hacia donde se desplace,
    // que pueda saltar y el grado de salto según si está sobre el suelo o no usando el raycast para comprobar la distancia
    // con respecto al suelo, y así determinar si lo está tocando o no. El salto se originará ejerciendo una fuerza
    // física que empuje el rigid body del personaje hacia arriba
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        float salto = Input.GetAxis("Jump");
        if (horizontal > 0.1f || horizontal < -0.1f)
        {
            if (horizontal > 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            animator.Play("PersonajeAndando");
        }
        else
        {
            animator.Play("PersonajeQuieto");
        }

        if (salto > 0)
        {
            // Lanzamos rayo hacia abajo
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new
                Vector2(0, -1));
            if (hit.collider != null)
            {
                float distanciaAlSuelo = hit.distance;
                bool tocandoElSuelo = distanciaAlSuelo < alturaPersonaje;
                if (tocandoElSuelo)
                {
                    Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                    rb.AddForce(fuerzaSalto);
                }
            }
        }
    }

    // Cuando el personaje colisione con un enemigo, se llamará a la función de perder vida del game controller, y se
    // reproducirá un efecto sonoro
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            FindObjectOfType<GameController>().PerderVida();
            AudioSource.PlayClipAtPoint(collision.gameObject.GetComponent<AudioSource>().clip, transform.position);
        }
    }

    // Esta función hará que el personaje vuelva a la posición inicial del nivel en el que se encuentre, se le llamará
    // de forma externa cuando el jugador pierda una vida
    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }
}