using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void LanzarJuego()
    {
        int a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
