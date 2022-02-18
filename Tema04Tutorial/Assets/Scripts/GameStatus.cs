using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public int itemsRecogidos = 0;
    public int puntos = 0;
    public int vidas = 3;
    [SerializeField] private Text textoPuntuacion;
    [SerializeField] private Text textoItems;

    [SerializeField] private Text textoVidas;

    // Esta función se ejecutará antes del Start(), se comprobará que no haya más de un game controller en el momento
    // en el que se cargue la escena. Si hay más de uno, se destruirá este game controller, pues es el sobrante, y si 
    // no hubiera más de uno, indicaremos al juego que no queremos que se destruya este game controller cuando se cargue
    // una nueva escena.
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
            foreach (Enemigo enemigo in FindObjectsOfType<Enemigo>())
            {
                enemigo.velocidad *= 2;
            }
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Por cada frame, se actualizará la información de items recogidos, puntuación y vida
    void Update()
    {
        textoItems.text = "Items: " + itemsRecogidos;
        textoPuntuacion.text = "Puntuación: " + puntos;
        textoVidas.text = "Vidas: " + vidas;
    }
}