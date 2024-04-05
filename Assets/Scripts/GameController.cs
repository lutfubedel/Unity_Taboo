using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Panel Up")]
    [SerializeField] private TMP_Text teamNameText;
    [SerializeField] private TMP_Text scoreText;

    [Header("Timer/Pass/Pause")]
    [SerializeField] private Image timerImage;
    [SerializeField] private TMP_Text passText;
    [SerializeField] private GameObject pausePanel;

    [Header("Words")]
    [SerializeField] private TMP_Text searchingWord;
    [SerializeField] private TMP_Text[] forbiddenWords;

    [Header("Values")]
    [SerializeField] private int raund;
    [SerializeField] private int score1;
    [SerializeField] private int score2;
    [SerializeField] private float totalTime;

    private float currentTime;

    List<List<string>> wordList = new List<List<string>>();


    private void Start()
    {
        wordList = GetComponent<Words>().wordList;

        raund = 1;
        score1 = 0;
        score2 = 0;

        if(raund % 2== 0)
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team2Name");
            scoreText.text = "Score : " + score2.ToString();
        }
        else
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team1Name");
            scoreText.text = "Score : " + score1.ToString();
        }

        passText.text = "(" + Mathf.Round(PlayerPrefs.GetFloat("Pass")).ToString() + ")";

        totalTime = PlayerPrefs.GetFloat("Time");
        currentTime = totalTime;

        SetWords();
    }


    private void FixedUpdate()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; 
            timerImage.fillAmount = currentTime / totalTime;
        }
        else
        {
            Debug.Log("Zaman doldu!");
            currentTime = 0; 
        }
    }



    private void SetWords()
    {
        int index = Random.Range(0,wordList.Count);

        searchingWord.text = wordList[index][0];

        for(int i=0; i<4; i++)
        {
            forbiddenWords[i].text = wordList[index][i + 1];
        }

        wordList.RemoveAt(index);
    }


    public void ButtonPause()
    {
        pausePanel.SetActive(true);
    }

    public void ButtonCorrect()
    {
        if (raund % 2 == 0)
        {
            score2++;
            scoreText.text = "Score : " + score2.ToString();
        }
        else
        {
            score1++;
            scoreText.text = "Score : " + score1.ToString();
        }

        SetWords();
    }

    public void ButtonTaboo()
    {
        if (raund % 2 == 0)
        {
            score2--;
            scoreText.text = "Score : " + score2.ToString();
        }
        else
        {
            score1--;
            scoreText.text = "Score : " + score1.ToString();
        }

        SetWords();
    }

    public void ButtonPass()
    {
        if(PlayerPrefs.GetFloat("Pass") > 0)
        {
            PlayerPrefs.SetFloat("Pass", PlayerPrefs.GetFloat("Pass") - 1);
            passText.text = "(" + Mathf.Round(PlayerPrefs.GetFloat("Pass")).ToString() + ")";
            
            SetWords();
        }
        else
        {
            PlayerPrefs.SetFloat("Pass", 0);
            passText.text = "(" + Mathf.Round(PlayerPrefs.GetFloat("Pass")).ToString() + ")";
        }
    }


}
