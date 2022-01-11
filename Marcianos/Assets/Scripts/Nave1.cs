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
    //Cuando se instancia la nave del jugador al cargar la escena, se inicializan los puntos
    // a cero y se inicializa el n�mero de enemigos al n�mero de enemigos que hay en pantalla
    void Start()
    {
        puntos = 0;
        enemigos = GameObject.FindObjectsOfType(typeof(Enemigo1)).Length;        
    }

    //Estas instrucciones se ejecutar�n una vez por cada frame o fotograma. Gestionan el movimiento
    //de la nave del jugador tomando los movimientos horizontal y vertical que el juego lea del
    //control del jugador. Tambi�n gestiona los l�mites de pantalla para que la nave no se
    //salga de la pantalla.
    //Asimismo, tambi�n gestiona que la nave dispare cuando se pulsa el bot�n Fire1, instanciando
    //un objeto disparo y d�ndole una velocidad que lo haga desplazarse hacia la izquierda.
    //Y por �ltimo, tambi�n gestiona el conteo de enemigos, que se sumen puntos cada vez que disminuye
    //el n�mero de enemigos, y que se muestre el mensaje de victoria cuando el n�mero de enemigos sea 0.
    void Update()
    {
        textoPuntuacion.text = "Puntuaci�n: " + puntos + "\n Enemigos: " + enemigos;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (transform.position.x > 4 && transform.position.y > 2.5)
        {
            if (vertical < 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x > 4 && transform.position.y < -2.5)
        {
            if (vertical > 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -4 && transform.position.y < -2.5)
        {
            if (vertical > 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if (horizontal > 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x < -4 && transform.position.y > 2.5)
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
        else if(transform.position.y > 2.5)
        {
            if(vertical < 0)
                transform.Translate(0, vertical * velocidad * Time.deltaTime, 0);
            if(horizontal != 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else if (transform.position.y < -2.5)
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
    //Gestiona qu� ocurrir� cuando la nave del jugador colisione con un collider. Si ese collider
    //tiene la etiqueta de enemigo o disparo de enemigo, la nave se destruye a s� misma y al disparo,
    //y muestra unas part�culas a modo de explosi�n. Con el sistema de etiquetas, evitamos que la nave
    //explote cuando instancie su propio disparo.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") || collision.CompareTag("DisparoEnemigo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
            textoPartidaPerdida.text = "Game over \n Has perdido";
        }
    }
}