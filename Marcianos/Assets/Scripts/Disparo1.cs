using UnityEngine;

public class Disparo1 : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;
    //Se llama por cada frame, si el disparo sale de la pantalla por la izquierda,
    //fuera de la vista de la cámara, se destruye.
    void Update()
    {
        if (transform.position.x < -4)
            Destroy(gameObject);
    }
    //Se llama cuando el disparo de la nave del jugador colisiona contra un enemigo,
    //destruyendo el disparo, la nave enemiga e instanciando una explosión.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
