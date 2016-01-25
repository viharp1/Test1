using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //public Texture backgroundTexture;

    private AudioSource audio;


    void OnGUI()
    {
        //Display backgroud
        //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        audio = gameObject.GetComponent<AudioSource>();


        //Display buttons
        if (GUI.Button(new Rect(Screen.width * .33f, Screen.height * .5f, Screen.width * .33f, Screen.height * .15f), "Play Game"))
        {
            audio.Play();
            // Opens the main game level
            SceneManager.LoadScene("Game");
        }

        if (GUI.Button(new Rect(Screen.width * .33f, Screen.height * .7f, Screen.width * .33f, Screen.height * .15f), "Options"))
        {
            print("Clicked Options");
        }

    }

}
