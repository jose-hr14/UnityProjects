using UnityEngine;

public class DisparoEnemigo1 : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;
    //Ejecutado por cada frame, se destruirá el disparo enemigo cuando este
    //salga de la pantalla por la derecha.
    void Update()
    {
        if (transform.position.x > 5)
            Destroy(gameObject);
    }
}
