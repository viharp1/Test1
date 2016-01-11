using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Rigidbody2D bullet;				// Prefab of the rocket.
	public float speed;				// The speed the rocket will fire at.

	//private Animator anim;					// Reference to the Animator component.
	
	void Awake()
	{
		// Setting up the references.
		//anim = transform.root.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		// If the fire button is pressed...
		if(Input.GetButtonDown("Fire1")) {
			// ... set the animator Shoot trigger parameter and play the audioclip.
			//anim.SetTrigger("Shoot");
			//GetComponent<AudioSource>().Play();
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
	}
}
