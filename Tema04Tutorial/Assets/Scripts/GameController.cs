using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int numeroSiguienteEscena;

    private Salida salida;

    // Recogeremos en variables el objeto salida que encontremos en la escena, y lo desactivaremos para que permanezca
    // oculto hasta que se recojan todos los items. Al estar guardado en una variable, podremos acceder aún estando
    // desactivado el objeto salida.
    void Start()
    {
        salida = FindObjectOfType<Salida>();
        salida.gameObject.SetActive(false);
    }

    // Esta función la llamaremos de forma externa, y lo que hará será restaruna vida al registro de las mismas que 
    // lleva el objeto game status. Si el número de vidas es menor o igual a cero, se llamará a la corutina game over.
    public void PerderVida()
    {
        if (FindObjectOfType<GameStatus>().vidas <= 0)
        {
            StartCoroutine(GameOver());
        }
        else
        {
            FindObjectOfType<GameStatus>().vidas -= 1;
            FindObjectOfType<Jugador>().SendMessage("Recolocar");
            Debug.Log("Quedan " + FindObjectOfType<GameStatus>().vidas + " vidas.");
        }
    }

    // Esta corutina ralentiza el tiempo durante 3 segundos y carga la escena game over, que mostrará que la partida
    // ha acabado junto a la puntuación obtenida.
    private IEnumerator GameOver()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOver");
    }

    public void AnotarItemRecogido()
    {
        FindObjectOfType<GameStatus>().puntos += 100;
        Debug.Log("Puntos: " + FindObjectOfType<GameStatus>().puntos);
        FindObjectOfType<GameStatus>().itemsRecogidos += 1;
        Debug.Log(("Items: " + FindObjectOfType<GameStatus>().itemsRecogidos));
        Debug.Log(FindObjectsOfType<Item>().Length);
        if (FindObjectsOfType<Item>().Length <= 1)
            salida.gameObject.SetActive(true);
    }

    public void AvanzarNivel()
    {
        if (SceneManager.sceneCountInBuildSettings == 1)
            Debug.Log("Fin del juego");
        SceneManager.LoadScene(numeroSiguienteEscena);
        FindObjectOfType<GameStatus>().itemsRecogidos = 0;
    }
}