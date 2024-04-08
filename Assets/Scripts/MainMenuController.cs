using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;

    [Header("Settings Sliders")]
    [SerializeField] private Slider sliderTime;
    [SerializeField] private Slider sliderPass;
    [SerializeField] private Slider sliderRound;

    [Header("Settings Values")]
    [SerializeField] private TMP_Text timeValue;
    [SerializeField] private TMP_Text passValue;
    [SerializeField] private TMP_Text roundValue;

    [Header("TeamNaming Parameters")]
    [SerializeField] private TMP_InputField inputTeam1Name;
    [SerializeField] private TMP_InputField inputTeam2Name;


    private void Start()
    {
        sliderTime.value = PlayerPrefs.GetFloat("Time");
        sliderPass.value = PlayerPrefs.GetFloat("Pass");
        sliderRound.value = PlayerPrefs.GetFloat("Round");
    }


    private void Update()
    {
        SliderSettings();
        TeamNameSettings();
    }

    private void SliderSettings()
    {
        if(panels[1].activeInHierarchy)
        {
            timeValue.text = Mathf.Round(sliderTime.value).ToString();
            passValue.text = Mathf.Round(sliderPass.value).ToString();
            roundValue.text = Mathf.Round(sliderRound.value).ToString();

            PlayerPrefs.SetFloat("Time", sliderTime.value);
            PlayerPrefs.SetFloat("Pass", sliderPass.value);
            PlayerPrefs.SetFloat("Round", sliderRound.value);
        }
    }

    private void TeamNameSettings()
    {
        if(panels[2].activeInHierarchy)
        {
            PlayerPrefs.SetString("Team1Name", inputTeam1Name.text);
            PlayerPrefs.SetString("Team2Name", inputTeam2Name.text);
        }
    }

    public void OpenSettingsMenu()
    {
        OpenPanel(1);
    }
    public void OpenTeamNaming()
    {
        OpenPanel(2);
    }
    public void ButtonBack()
    {
        OpenPanel(0);
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenPanel(int index)
    {
        for(int i=0; i<panels.Length;i++)
        {
            if(i == index)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
    }
}
