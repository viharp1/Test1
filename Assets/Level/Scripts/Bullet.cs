using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject blood;

	// Use this for initialization
	void Start () {
		// Destroy the bullet after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}

	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the blood drop where the bullet is with the random rotation.
		Instantiate(blood, transform.position, randomRotation);
	}
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<EnemyScript>().Hurt();

			// Call the explosion instantiation.
			OnExplode();

			// Destroy the bullet.
			Destroy (gameObject);
		}
	}
}
