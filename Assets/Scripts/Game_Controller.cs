using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public static GameObject Player;

    public GameObject Target;

    //UI
    public Dropdown Player_Color_Selector;
    public Slider Player_Size_Selector;

    //Variables for the pause system
    public bool Game_Paused;
    private bool Pause_Held;
    
    //Called when the Object is created
    private void Awake()
    {
        Master_Manager.Player_Score = 0; //Makes sure the score is reset when scene is loaded.

        //Makes sure the game is unpaused when the scene starts
        Time.timeScale = 1;
        Game_Paused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player"); //Finds the Player and stores them in a Static Variable for other Scripts to use

        SpawnTargets(5); //Spawn in Five Targets
    }

    // Update is called once per frame
    void Update()
    {
        //Assigns the player's scale to the slider value.
        Player.transform.localScale = new Vector3(Player_Size_Selector.value, Player_Size_Selector.value, Player_Size_Selector.value);

        Player_Color(); 

        Pause_Control();

        //Checks if the Player has enough score to move to the final scene
        if (Master_Manager.Player_Score >= 5)
        {
            SceneManager.LoadScene("Exit");
        }
    }

    //Spawns the Target Prefab the amount of times requested
    void SpawnTargets(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(Target, new Vector3(Random.Range(-4, 4), 1, Random.Range(-4, 4)), Quaternion.identity);
        }
    }

    //Assigns the player the color they should be from the dropdown menu
    private void Player_Color()
    {
        //Gets the vlaue from the dropbox and changes the color accordingly
        switch (Player_Color_Selector.value)
        {
            case 0: //Default: Green
                {
                    Player.GetComponent<Renderer>().material.color = Color.green;
                    break;
                }
            case 1: //Yellow
                {
                    Player.GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                }
            case 2: //Blue
                {
                    Player.GetComponent<Renderer>().material.color = Color.blue;
                    break;
                }
            default: //Shouldn't be used but incase the input value is out of the switch range. //Color is set to red in this case
                {
                    Player.GetComponent<Renderer>().material.color = Color.red;
                    break;
                }
        }
    }

    //Contains the system to controll pausing and resuming the game
    private void Pause_Control()
    {
        float Pause_Input = Input.GetAxisRaw("Cancel"); //Gets the Cancel Input from unity input and stores it

        //Checks if the pause button has been released so it doesn't constantly pause and unpause the game.
        if (Input.GetKeyUp(KeyCode.P))
        {
            Pause_Held = false;
            Debug.Log("P key released");
        }

        //Gets Keyboard Input to resume the game
        if (Pause_Input >= 0.1 && Pause_Held == false && Game_Paused == true)
        {
            Time.timeScale = 1; //Resumes the Game

            Pause_Held = true;
            Game_Paused = false;

            Debug.Log("Game Unpaused");
        }

        //Gets Keyboard Input to pause the game
        if (Pause_Input >= 0.1 && Pause_Held == false && Game_Paused == false)
        {
            Time.timeScale = 0; //Pauses the Game

            Pause_Held = true;
            Game_Paused = true;

            Debug.Log("Game Paused");
        }
    }
}
