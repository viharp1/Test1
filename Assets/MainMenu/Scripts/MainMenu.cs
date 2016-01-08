using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;    
    


    void OnGUI()
    {
        //Display backgroud
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        


        //Display buttons
        if (GUI.Button(new Rect(Screen.width * .33f, Screen.height * .5f, Screen.width * .33f, Screen.height * .1f), "Play Game"))
        {
            print("Clicked Play Game");
        }

        if (GUI.Button(new Rect(Screen.width * .33f, Screen.height * .7f, Screen.width * .33f, Screen.height * .1f), "Options"))
        {
            print("Clicked Options");
        



    }


    }



}
