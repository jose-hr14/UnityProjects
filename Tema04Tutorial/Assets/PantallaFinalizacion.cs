using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scene = UnityEditor.SearchService.Scene;

public class PantallaFinalizacion : MonoBehaviour
{
    // Start is called before the first frame update
    private int puntuacion;
    [SerializeField] Text textoResultado;
    void Start()
    {
        if (FindObjectOfType<GameStatus>() != null)
        {
            textoResultado.text = "Puntuación obtenida: " + FindObjectOfType<GameStatus>().puntos;
            Destroy(FindObjectOfType<GameStatus>().gameObject);
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
            StartCoroutine(VolverPantallaPrincipal());
    }

    IEnumerator VolverPantallaPrincipal()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Título");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
