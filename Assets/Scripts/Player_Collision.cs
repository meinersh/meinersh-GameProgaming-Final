using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Compares the Tag of the object the Player Collides with.
        switch (collision.gameObject.tag)
        {
            case ("Target"):
                {
                    Destroy(collision.gameObject); //Destories the Target Object

                    Master_Manager.Player_Score += 1; //Updates the player's score

                    break;  
                }
            default:
                {
                    break;
                }
        }
    }
}
