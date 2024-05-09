using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    public Text Player_Name_Display;
    public Text Player_Size_Display;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Player_Name_Display.text = Master_Manager.Player_Name; //Sets the Display to player name
    }

    // Update is called once per frame
    void Update()
    {
        Player_Size_Display.text = "" + Game_Controller.Player.transform.localScale.x; //Gets the current scale of the player and displays it
        Score.text = "" + Master_Manager.Player_Score; //Gets the player score and displays it
    }
}
