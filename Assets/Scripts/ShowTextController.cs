using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowTextController : MonoBehaviour
{
    public GameObject panel;

    public string[] initialDialogue;
    public string[] closingDialogue;

    public Text txtDialogue;
    public bool isDialogueActive;

    Coroutine auxCoroutine;

    public Button startButton;
    public Button continueButton;
    public Button playButton;

    public Image oldWomen;
    public Image youngWomen;

    public AudioClip buttonSFX;
    private AudioSource audiosource;
    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void OpenDialogueBox(int value)
    {
        if (isDialogueActive)
        {            
            StartCoroutine(WaitDialogueAppearance(value));
        }
        else
        {
            isDialogueActive = false;
            auxCoroutine = StartCoroutine(ShowDialogue(value));
        }
    }

    IEnumerator ShowDialogue(int value, float time = 0.1f)
    {
        panel.SetActive(true);
        string[] dialogue;
        if (value == 0)
        {
            dialogue = initialDialogue;
        }
        else
        {
            dialogue = closingDialogue;
        }

        int total = dialogue.Length;
        string rest = "";
        isDialogueActive = true;
        yield return null;

        for (int i = 0; i < total; i++)
        {
            rest = "";
            if (isDialogueActive)
            {
                for (int s = 0; s < dialogue[i].Length; s++)
                {
                    if (isDialogueActive)
                    {
                        rest = string.Concat(rest, dialogue[i][s]);
                        txtDialogue.text = rest;
                        yield return new WaitForSeconds(time);
                    }
                    else
                    {                        
                        yield break;
                    }
                }
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                yield break;
            }
        }
        yield return new WaitForSeconds(0.4f);        
    }

    IEnumerator WaitDialogueAppearance(int value)
    {
        yield return new WaitForEndOfFrame();
        auxCoroutine = StartCoroutine(ShowDialogue(value));
    }


    public void CloseDialogue()
    {
        isDialogueActive = false;
        if (auxCoroutine != null)
        {
            StopCoroutine(auxCoroutine);
            auxCoroutine = null;
        }
        txtDialogue.text = "";
        panel.SetActive(false);

    }
    
    public void OnStartButton()
    {
        audiosource.PlayOneShot(buttonSFX);
        OpenDialogueBox(0);
        startButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        oldWomen.gameObject.SetActive(true);
    }

    public void OnNextButton()
    {
        audiosource.PlayOneShot(buttonSFX);
        OpenDialogueBox(1);
        oldWomen.gameObject.SetActive(false);
        youngWomen.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }
    public void OnPlayButton()
    {
        audiosource.PlayOneShot(buttonSFX);
        SceneManager.LoadScene("Menu");
    }

}