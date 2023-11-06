using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{



    //This function tells the game what to do when the player collides with the items
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If statment saying the condition
        if (other.transform.tag == "Player")
        {

            //This allows the game to remove the item once the player has collided with it
            Destroy(gameObject);

        }

    }
}
