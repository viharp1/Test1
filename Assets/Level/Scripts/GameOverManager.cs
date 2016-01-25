using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public GameObject player;       // Reference to the player's health.
    public float restartDelay = 5f;

    float restartTimer;
    PlayerBehaviourScript playerScript;
    bool gameOver;

    // Use this for initialization
    void Start () {
        playerScript = player.gameObject.GetComponent<PlayerBehaviourScript>();

    }

    // Update is called once per frame
    void Update () {
        // TODO: fix this
        // If the player has run out of health...
        if (!gameOver && playerScript.getHealth() <= 0)
        {
            gameOver = true;
            Destroy(player);
            GetComponent<AudioSource>().Play();
            GetComponent<Text>().text = "GAME OVER!";
        }
        if (gameOver)
        {
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
