//by Herve Mucyo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
