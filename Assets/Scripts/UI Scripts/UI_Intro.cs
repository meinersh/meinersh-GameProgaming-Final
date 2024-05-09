using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Intro : MonoBehaviour
{
    public InputField Player_Name_Input;

    //Stores the name in the input field in Master_Manager
    public void StorePlayerName()
    {
        Master_Manager.Player_Name = Player_Name_Input.text;
    }
}
