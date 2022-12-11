using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public PlayerController movement;
    private void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "Player") 
        {
            movement.enabled = false; //disable player movment
            FindObjectOfType<GM>().Win();
        }
    }
}
