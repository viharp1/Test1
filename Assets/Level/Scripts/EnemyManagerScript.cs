using UnityEngine;
using System.Collections;

public class EnemyManagerScript : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    private PlayerBehaviourScript playerScript;

	// Use this for initialization
	void Start () {
        playerScript = player.gameObject.GetComponent<PlayerBehaviourScript>();
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}

    void Spawn ()
    {
        int playerHealth = playerScript.getHealth();
        if (playerHealth > 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Instantiate the newEnemy and also assign its player target to be the player
            GameObject newEnemy = (GameObject) Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            newEnemy.GetComponent<EnemyScript>().player = player.transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
