using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salida : MonoBehaviour
{
    [SerializeField] private AudioSource musicaFondo;
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            musicaFondo.Stop();
            GetComponent<AudioSource>().Play();
            StartCoroutine(FindObjectOfType<GameController>().JuegoCompletado());
        }
    }
}
