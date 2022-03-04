using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        FindObjectOfType<GameStatus>().enemigosRestantes = 0;
    }

    public IEnumerator GameOver()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        Destroy(FindObjectOfType<Jugador>().gameObject);
        SceneManager.LoadScene("GameOver");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public IEnumerator JuegoCompletado()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.6f);
        Time.timeScale = 1;
        SceneManager.LoadScene("PantallaJuegoCompletado");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
