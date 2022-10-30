using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject panelInstructions;

    public AudioClip buttonSFX;
    private AudioSource audiosource;

    public static bool isSafeOpened = false;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    void Start()
    {
        panelInstructions.SetActive(false);
    }

    void Update()
    {
        if (isSafeOpened)
        {
            panelInstructions.SetActive(false);
        }
    }
    public void OnButtonCredits()
    {
        audiosource.PlayOneShot(buttonSFX);
        panelInstructions.SetActive(true);
    }
    public void OnCloseButton()
    {
        audiosource.PlayOneShot(buttonSFX);
        panelInstructions.SetActive(false);
    }

}
