using UnityEngine;

public class DisparoEnemigo1 : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;
    
    void Update()
    {
        if (transform.position.x > 5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
    }
}
