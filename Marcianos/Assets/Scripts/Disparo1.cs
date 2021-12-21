using UnityEngine;

public class Disparo1 : MonoBehaviour
{
    [SerializeField] Transform prefabExplosion;

    void Update()
    {
        if (transform.position.y > 3)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Transform explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            Destroy(explosion.gameObject, 1f);
        }
    }


}
