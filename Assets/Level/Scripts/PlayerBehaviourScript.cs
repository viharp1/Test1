using UnityEngine;
using System.Collections;

public class PlayerBehaviourScript : MonoBehaviour {

    public float speed;

    public GameObject blood;

    private Rigidbody2D rb;

    private int health = 3;

    // Use for physics
    void FixedUpdate()
    {
        
        rb = GetComponent<Rigidbody2D>();
       

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(gameObject.transform.up*speed*moveVertical);
        rb.AddForce(gameObject.transform.right * speed * moveHorizontal);
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
        // If we hit an enemy...
        if(col.tag == "Enemy")
        {
            // take some damage
            takeDamage();

            // Call the explosion instantiation.
            OnExplode();
        }
    }

    void takeDamage() {
        if (health == 1) {
            // TODO: end the game
            Destroy(gameObject, 1);
        } else {
            health--;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
