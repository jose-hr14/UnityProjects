using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Lanza el primer nivel de juego cuando se clica en el bot?n
    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
