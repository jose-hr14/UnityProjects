using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameController gameController;

    [SerializeField] AudioClip audioClip;

    // Recogemos en una variable el game controller para poder llamarlo en posteriores funciones
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Cuando el item colisione con el jugador, se llamará al método de anotar item recogido del game controller,
    // para anotar el item recogido y aumentar la puntuación. Además, se reproducirá un efecto sonoro y se destruirá
    // el item
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.SendMessage("AnotarItemRecogido");
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Destroy(gameObject);
        }
    }
}