using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    
    public GameObject panelGameOver;

    public static bool isSafeOpened = false;

    public AudioClip buttonSFX;
    private AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Start()
    {
        panelGameOver.SetActive(false);
    }

    void Update()
    {
        if (isSafeOpened)
        {
            panelGameOver.SetActive(false);
        }
    }
    public void OnButtonContinue()
    {
        audiosource.PlayOneShot(buttonSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
