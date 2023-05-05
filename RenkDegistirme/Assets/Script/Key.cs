using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Ov yeah");
        if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("LevelsScene");
                
            }
        }

    
}
