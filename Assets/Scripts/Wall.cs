using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    void OnMouseOver()
    {        
        if (gameObject.CompareTag("Line"))
        {            
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }        
    }
}
