using UnityEngine;

public class Nave1 : MonoBehaviour
{
    [SerializeField] float velocidad = 10;
    [SerializeField] Transform prefabDisparo;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] float velocidadDisparo = -2;
    [SerializeField] int puntos;
    [SerializeField] int enemigos;
    [SerializeField] UnityEngine.UI.Text textoPuntuacion;
    [SerializeField] UnityEngine.UI.Text textoPartidaGanada;
    [SerializeField] UnityEngine.UI.Text textoPartidaPerdida;
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        enemigos = GameObject.FindObjectsOfType(typeof(Enemigo1)).Length;        
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntuacion.text = "Puntuación: " + puntos + "\n Enemigos: " + enemigos;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (transform.position.x > 4 && transform.position.y > 3)
        {
            if (vertical < 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x > 4 && transform.position.y < -3)
        {
            if (vertical > 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -4 && transform.position.y < -3)
        {
            if (vertical > 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal > 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -4 && transform.position.y > 3)
        {
            if (vertical < 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal > 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -4)
        {
            if (horizontal > 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
            if (vertical != 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
        }
        else if (transform.position.x > 4)
        {
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
            if(vertical != 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
        }
        else if(transform.position.y > 3)
        {
            if(vertical < 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if(horizontal != 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y < -3)
        {
            if (vertical > 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal != 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else
            transform.Translate(horizontal * velocidad * Time.deltaTime, vertical * velocidad * Time.deltaTime, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Transform disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(velocidadDisparo,
                0, 0);
            GetComponent<AudioSource>().Play();

        }
        if(enemigos > GameObject.FindObjectsOfType(typeof(Enemigo1)).Length)
        {
            enemigos = GameObject.FindObjectsOfType(typeof(Enemigo1)).Length;
            puntos += 5;
        }
        if(enemigos == 0)
        {
            textoPartidaGanada.text = "Bravo \n Has ganado";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            textoPartidaPerdida.text = "Game over \n Has perdido";
        }
    }
}