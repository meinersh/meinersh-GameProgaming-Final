using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Exit : MonoBehaviour
{
    public Text High_Score_Display;

    // Start is called before the first frame update
    void Start()
    {
        High_Score_Display.text = Master_Manager.Player_Name + ": " + Master_Manager.Player_Score;
    }
}
