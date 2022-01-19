using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {	
	// Creamos variables publicas para al velocidad del jugador y para los textos del canvas
	public float speed;
	public Text countText;
	public Text winText;
	private Renderer r;
	public float fuerzaDeSalto = 5;
	public Transform particulasPared;
	public Transform particulasPickUp;

	// Creamos referencias privadas al componente rigidbody del jugador, y para al cuenta de pick ups que se vayan recogiendo
	private Rigidbody rb;
	private int count;

	// Al comienzo del juego...
	void Start ()
	{
		// Asignamos a la variable rb la dirección de memoria del rigidbody, y a la variable r la del renderes
		rb = GetComponent<Rigidbody>();
		r = GetComponent<Renderer>();

		// Ponemos la cuenta de pick ups a cero
		count = 0;

		// Llamamos a al función SetCountText para actualizar la interfaz de usuario
		SetCountText ();

		// Pone el texto de victoria como vacío
		winText.text = "";
	}
	//Se llamará por cada frame
    private void Update()
    {
		// Al pulsar el botón de saltar, y si la pelota está sobre el suelo, ejerce una fuerza
		// en el eje y hacia arriba que impulsa al pelota haciéndola saltar
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1F)
        {
			rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
        }
    }
    // Se llamará cada 0.2 segundo o cual sea el lapso de tiempo que se haya elegido en la configuracion de unity
	// Aquí irá el código relativo a las físicas del juego, pues queremos que se ejecturene en un lapso de tiempo
	// constante
    void FixedUpdate ()
	{
		// Declaramos algunas variables locales equivalentes al input horizontal y vertical
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		// Creamos una variable Vector3, le asignamos a la X el valor que saquemos del input horizonta, y z al que 
		// saquemos del input vertical
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Añadimos una fuerza física al rigidbody del jugar utilizando el vector que hemos creado
		// con los valores del input horizontal y vertical leídos del control. Esto lo multiplicamos
		// por el atributo público de clase de la velocidad
		rb.AddForce (movement * speed);
	}

	// Cuando el juego entre en contacto con un collider que tenga marcado el is trigger
	// guardará en la variable other una referencia a ese collider...
	void OnTriggerEnter(Collider other) 
	{
		// y si el objeto is trigger tiene la etiqueta de Pick Up asignada...
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Pone el objeto como inactivo, haciéndolo desaparecer
			other.gameObject.SetActive (false);

			// Suma 1 al contador de pick ups
			count = count + 1;

			// Llama al procedimiento SetCountText()
			SetCountText ();

			// Si la escala en el eje x es menor que cinco, incrementamos su tamaño en 0.05 en todos su ejes
			if (transform.localScale.x < 5)
				transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
			// Instanciamos un sistema de partículas en la posición en la que estaba la bola en el momento de
			// coger el pick up, y lo destruye al segundo después
			Transform particulasPickUpInstanciadas = Instantiate(particulasPickUp, gameObject.transform.position, Quaternion.identity);			
			Destroy(particulasPickUpInstanciadas.gameObject, 1);
		}
	}

	// Procedimiento que actualiza el texto del conteo de pick ups y comprueba se ha han cogido todos para mostrar el texto de 
	// victoria
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ParedHorizontal"))
        {
			r.material.color = new Color(Mathf.Round(Random.value),
				Mathf.Round(Random.value), Mathf.Round(Random.value));
			if(transform.localScale. x < 5)
				transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
			if (collision.transform.localScale.y > 3)
            {
				collision.transform.localScale -= new Vector3(0, 3f, 0);
				collision.transform.position -= new Vector3(0, 1.5f, 0);
			}
			else
				Destroy(collision.gameObject);
			Transform particulasParedInstanciadas = Instantiate(particulasPared, gameObject.transform.position, Quaternion.identity);
			Destroy(particulasParedInstanciadas.gameObject, 1);
		}
		if (collision.gameObject.CompareTag("ParedVertical"))
		{
			r.material.color = new Color(Mathf.Round(Random.value),
				Mathf.Round(Random.value), Mathf.Round(Random.value));
			if (transform.localScale.x > 1)
				transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
			if (collision.transform.localScale.y > 3)
			{
				collision.transform.localScale -= new Vector3(0, 3f, 0);
				collision.transform.position -= new Vector3(0, 1.5f, 0);
			}
			else
				Destroy(collision.gameObject);

			Transform particulasParedInstanciadas = Instantiate(particulasPared, gameObject.transform.position, Quaternion.identity);
			Destroy(particulasParedInstanciadas.gameObject, 1);
		}
	}
}