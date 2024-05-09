using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Tests
{
    [UnityTest]
    public IEnumerator PlayButtonStartsPlay()
    {
        SceneManager.LoadScene("Intro");

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the play button
        Button Play_Button = GameObject.Find("PlayButton").GetComponent<Button>();

        Play_Button.onClick.Invoke(); //Calls the on click function

        yield return new WaitForSecondsRealtime(0.1f);

        Assert.AreEqual("Game",SceneManager.GetActiveScene().name); //Checks if the scene name matches
    }

    [UnityTest]
    public IEnumerator StopButtonStopsPlay()
    {
        SceneManager.LoadScene("Exit");

        Master_Manager.Testing_Running = true; //This is here so that the test player doesn't stop while testing. Only needed in this test.

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Quit button
        Button Quit_Button = GameObject.Find("QuitButton").GetComponent<Button>();

        Quit_Button.onClick.Invoke(); //Calls the on click function

        Assert.AreEqual(false, Master_Manager.Game_Running); //Checks if the value has been updated
    }

    [UnityTest]
    public IEnumerator PlayAgainButtonRestartsGame()
    {
        SceneManager.LoadScene("Exit");

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Play Again button
        Button Play_Again_Button = GameObject.Find("PlayAgainButton").GetComponent<Button>();

        Play_Again_Button.onClick.Invoke(); //Calls the on click function

        yield return new WaitForSecondsRealtime(0.1f);

        Assert.AreEqual("Intro", SceneManager.GetActiveScene().name); //Checks if the scene name matches
    }

    [UnityTest]
    public IEnumerator PlayerNameShownInGame()
    {
        SceneManager.LoadScene("Intro");

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Play Button and the Name Input Field
        Button Play_Button = GameObject.Find("PlayButton").GetComponent<Button>();
        InputField Name_Input = GameObject.Find("NameInputField").GetComponent<InputField>();

        Name_Input.text = "Barney"; //Sets the name to a value

        Play_Button.onClick.Invoke(); //Calls the on click function

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Name_Display and stores the current text value
        string Name_Display = GameObject.Find("NameText").GetComponent<Text>().text;

        Assert.AreEqual(Master_Manager.Player_Name, Name_Display); //Checks if the name display and the name store in Master_Manager match. 
    }

    [UnityTest]
    public IEnumerator DestroyingFiveTargetsStopsPlay()
    {
        SceneManager.LoadScene("Game");

        yield return new WaitForSecondsRealtime(0.1f);

        GameObject[] Targets = GameObject.FindGameObjectsWithTag("Target"); //Finds all of the targets in the scene and stores them in an array

        for (int i = 0; i < Targets.Length; i++)
        {
            //Picks a Target Gameobject that still exists and sets the player location it it's location
            Game_Controller.Player.transform.position = GameObject.FindWithTag("Target").transform.position; 

            yield return new WaitForSecondsRealtime(0.1f);
        }

        yield return new WaitForSecondsRealtime(0.1f);

        Assert.AreEqual("Exit", SceneManager.GetActiveScene().name); //Checks if the scene name matches
    }

    [UnityTest]
    public IEnumerator NameFromIntroShowsInGameScene()
    {
        SceneManager.LoadScene("Intro");

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Play Button and the Name Input Field
        Button Play_Button = GameObject.Find("PlayButton").GetComponent<Button>();
        InputField Name_Input = GameObject.Find("NameInputField").GetComponent<InputField>();

        Name_Input.text = "Barney"; //Sets the name to a value

        Play_Button.onClick.Invoke(); //Calls the on click function

        yield return new WaitForSecondsRealtime(0.1f);

        //Finds the Name_Display and stores the current text value
        string Name_Display = GameObject.Find("NameText").GetComponent<Text>().text;

        Assert.AreEqual(Master_Manager.Player_Name, Name_Display); //Checks if the name display and the name store in Master_Manager match. 
    }
}
