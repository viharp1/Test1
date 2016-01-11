using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{

    public Texture backgroundTexture;



    void OnGUI()
    {
        //Display backgroud
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

    }



}
