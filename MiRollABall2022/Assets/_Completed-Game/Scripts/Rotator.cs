using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public Vector3 giro; // Before rendering each frame..
    public Renderer renderer;

    private void Start()
    {
        giro = new Vector3(Random.Range(0, 45), Random.Range(0, 45),
            Random.Range(0, 45));
        renderer = gameObject.GetComponent<Renderer>();
        StartCoroutine(CambiarColor());
    }

    void Update () 
    { 
        transform.Rotate (giro * Time.deltaTime); 
    }
    IEnumerator CambiarColor()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        renderer.material.color = new Color(Random.value,
            Random.value, Random.value);
        StartCoroutine(CambiarColor());
    }
}	