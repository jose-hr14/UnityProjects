using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] int numeroSiguienteEscena;
    // Recogeremos en variables el objeto salida que encontremos en la escena, y lo desactivaremos para que permanezca
    // oculto hasta que se recojan todos los items. Al estar guardado en una variable, podremos acceder aún estando
    // desactivado el objeto salida.
    void Start()
    {

    }

    public void AnotarEnemigoDerrotado()
    {
        FindObjectOfType<GameStatus>().puntos += 100;
        Debug.Log("Puntos: " + FindObjectOfType<GameStatus>().puntos);
        FindObjectOfType<GameStatus>().enemigosRestantes -= 1;
        Debug.Log(("Enemigos restantes: " + FindObjectOfType<GameStatus>().enemigosRestantes));
        Debug.Log(FindObjectsOfType<Enemigo>().Length);
        if (FindObjectOfType<GameStatus>().enemigosRestantes < 1)
        {
            AvanzarNivel();
        }
    }

    public void AvanzarNivel()
    {
        if (SceneManager.sceneCountInBuildSettings == 1)
            Debug.Log("Fin del juego");
        SceneManager.LoadScene(numeroSiguienteEscena);
        FindObjectOfType<GameStatus>().enemigosRestantes = 0;
    }
}
