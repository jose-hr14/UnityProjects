using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int itemsRecogidos;
    public int puntos = 0;
    public int vidas = 3;
    public int nivelActual = 1;
    public int nivelMasAlto = 2;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameController>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        vidas = 3;
        itemsRecogidos = 0;
    }
    public void PerderVida()
    {
        vidas--;
        FindObjectOfType<Jugador>().SendMessage("Recolocar");
        Debug.Log("Quedan " + vidas + " vidas.");
        if(vidas <= 0){
            Debug.Log("Partida terminada");
            Application.Quit();
        }
    }
    public void AnotarItemRecogido()
    {
        puntos += 100;
        Debug.Log("Puntos: " + puntos);
        itemsRecogidos++;
        Debug.Log(("Items: " + itemsRecogidos));
        if (FindObjectsOfType<Item>().Length <= 0)
            FindObjectOfType<Salida>().gameObject.SetActive(true);
    }
    public void AvanzarNivel()
    {
        if(SceneManager.sceneCountInBuildSettings == 1)
            Debug.Log("Fin del juego");
        SceneManager.LoadScene("Nivel2");
        itemsRecogidos = 0;
    }
}
