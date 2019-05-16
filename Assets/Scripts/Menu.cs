using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject[] soundButton;
    [SerializeField] GameObject howToPlayPanel;
    [SerializeField] Text howToPlayText;

    bool panelActive;

    void Start()
    {
        //howToPlayPanel.SetActive(false);
        panelActive = false;
        howToPlayText.text = "?";

        if (AudioListener.volume == 0)
        {
            soundButton[1].SetActive(true);
            soundButton[0].SetActive(false);
        }
        else
        {
            soundButton[0].SetActive(true);
            soundButton[1].SetActive(false);
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SoundButton()
    {
        SoundControll();
    }

    void SoundControll()
    {
        if (AudioListener.volume != 0)
        {
            AudioListener.volume = 0;
            soundButton[1].SetActive(true);
            soundButton[0].SetActive(false);
        }
        else
        {
            AudioListener.volume = 1;
            soundButton[0].SetActive(true);
            soundButton[1].SetActive(false);
        }
    }

    public void HowToPlayPanel()
    {
        if (panelActive == false)
        {
            panelActive = true;
            howToPlayPanel.SetActive(true);
            howToPlayText.text = "BACK";
        }
        else if (panelActive == true)
        {
            panelActive = false;
            howToPlayPanel.SetActive(false);
            howToPlayText.text = "?";
        }
    }
}
