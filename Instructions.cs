using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour
{
    public TextMeshProUGUI uiObj;
    private void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "Player") 
        {
            uiObj.gameObject.SetActive(true);
            StartCoroutine("Wait"); // pause execution for another process to run 
        }
    }

    IEnumerator Wait() 
    {
        yield return new WaitForSeconds(4); // create a timer thread
        Destroy(uiObj);
        Destroy(gameObject);
    }
}
