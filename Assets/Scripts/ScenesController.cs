using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public AudioClip buttonSFX;
    private AudioSource audiosource;
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void OnButtonMenu()
    {
        audiosource.PlayOneShot(buttonSFX);
        SceneManager.LoadScene("Menu");
    }
    public void OnButtonCredits()
    {
        audiosource.PlayOneShot(buttonSFX);
        SceneManager.LoadScene("Credits");
    }
    public void OnButtonPlay()
    {
        audiosource.PlayOneShot(buttonSFX);
        SceneManager.LoadScene("Level1");
    }

}
