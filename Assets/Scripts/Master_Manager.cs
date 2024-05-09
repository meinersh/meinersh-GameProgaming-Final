using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Manager : MonoBehaviour
{
    //For the DontDestoryOnLoad
    public static Master_Manager Instance;

    //Stores the Players name
    public static string Player_Name = "DEFAULT";

    //Player Score
    public static float Player_Score;

    public static bool Game_Running;
    public static bool Testing_Running = false;

    //Runs when the object is first created.
    private void Awake()
    {
        //Singleton so that there is only ever one Instance of this object.
        if (Instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate Master_Manager deleted");
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        Game_Running = true;
    }

    //Typically called when a button is pressed. Enter the scene name and it will load the scene requested.
    public void GoToScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    //Exits the application when Pressed
    public void ExitGame()
    {
        Game_Running = false;

        Application.Quit(); //Igonred in editor mode
        
        if (Testing_Running == false)
        {
            EditorApplication.ExitPlaymode();
        }
        
    }
}
