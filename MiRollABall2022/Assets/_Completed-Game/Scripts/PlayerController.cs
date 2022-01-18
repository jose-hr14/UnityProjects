﻿using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public Text countText;
	public Text winText;
	private Renderer r;
	public float fuerzaDeSalto = 5;
	public Transform particulasPared;
	public Transform particulasPickUp;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
		r = GetComponent<Renderer>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";
	}

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.1F)
        {
			rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
        }
    }

    // Each physics step..
    void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			if (transform.localScale.x < 3)
				transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
			Transform particulasPickUpInstanciadas = Instantiate(particulasPickUp, gameObject.transform.position, Quaternion.identity);			
			Destroy(particulasPickUpInstanciadas.gameObject, 1);
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 12) 
		{
			// Set the text value of our 'winText'
			winText.text = "You Win!";
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ParedHorizontal"))
        {
			r.material.color = new Color(Mathf.Round(Random.value),
				Mathf.Round(Random.value), Mathf.Round(Random.value));
			if(transform.localScale. x < 5)
				transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
			if (collision.transform.localScale.y > 3)
            {
				collision.transform.localScale -= new Vector3(0, 3f, 0);
				collision.transform.position -= new Vector3(0, 1.5f, 0);
			}
			else
				Destroy(collision.gameObject);
			Transform particulasParedInstanciadas = Instantiate(particulasPared, gameObject.transform.position, Quaternion.identity);
			Destroy(particulasParedInstanciadas.gameObject, 1);
		}
		if (collision.gameObject.CompareTag("ParedVertical"))
		{
			r.material.color = new Color(Mathf.Round(Random.value),
				Mathf.Round(Random.value), Mathf.Round(Random.value));
			if (transform.localScale.x > 0.5)
				transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
			if (collision.transform.localScale.y > 3)
			{
				collision.transform.localScale -= new Vector3(0, 3f, 0);
				collision.transform.position -= new Vector3(0, 1.5f, 0);
			}
			else
				Destroy(collision.gameObject);

			Transform particulasParedInstanciadas = Instantiate(particulasPared, gameObject.transform.position, Quaternion.identity);
			Destroy(particulasParedInstanciadas.gameObject, 1);
		}
	}
}