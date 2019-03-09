using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
	// Start is called before the first frame update

   	public int speed;
   	//public Color color;

// Function called when the enemy is created
	private void Start () {

		this.speed = -5; 
		//this.color = Blue;
		// Get the rigidbody component

		// Add a vertical speed to the enemy

		Rigidbody2D rgb = this.GetComponent<Rigidbody2D>();
		rgb.velocity = new Vector2(0, speed);

	// Make the enemy rotate on itself
	//r2d.angularVelocity = Random.Range(-200, 200);
	}

// Function called when the object goes out of the screen
	private void OnBecameInvisible() {

	// Destroy the enemy
		Destroy(gameObject);
		} 
	}
