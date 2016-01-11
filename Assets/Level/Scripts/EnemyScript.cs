using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public float speed;
    public Transform player;
    private int health = 3;

	// Update is called once per frame
	void FixedUpdate () {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
    }

    public void Hurt() {
   		//TODO: slow the enemy for a second?
    	if (health == 1) {
    		Destroy(gameObject);
    	} else {
    		health--;
    	}
    }
}
