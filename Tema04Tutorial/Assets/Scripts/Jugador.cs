using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidad = 5;
    [SerializeField] float velocidadSalto = 20;
    GameController gameController;

    private Animator animator;
    
    private float xInicial, yInicial;

    private Rigidbody2D rb;
    private float alturaPersonaje;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        animator = gameObject.GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
        GetComponent<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        float salto = Input.GetAxis("Jump");
        if(horizontal > 0.1f || horizontal < -0.1f)
        {
            if(horizontal > 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            FindObjectOfType<GameController>().PerderVida();
        }
    }

    public void Recolocar()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }

}
