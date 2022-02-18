using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    // Esta función se llamará cuando se pulse el botón en la pantalla del título, y lo que hará será cargar el primer
    // nivel.
    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }
}