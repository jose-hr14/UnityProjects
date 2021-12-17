using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField] float velocidad = 10;
    [SerializeField] Transform prefabDisparo;
    [SerializeField] float velocidadDisparo = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        

        if (transform.position.x < -4)
        {
            if(horizontal > 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }            
        else if (transform.position.x > 4)
        {
            if (horizontal < 0)
                transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        else
            transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
            
        if(Input.GetButtonDown("Fire1"))
        {
            Transform disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
            disparo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 
                velocidadDisparo, 0);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Golpeado!");
    }
}
