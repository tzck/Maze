using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController movement; // reference to PlayerController script
    private void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "Player") 
        {
            movement.enabled = false; //disable player movment
            FindObjectOfType<GM>().GameOver();
        }
    }
}
