using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBetweenScenes : MonoBehaviour
{
    public static AudioBetweenScenes instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
