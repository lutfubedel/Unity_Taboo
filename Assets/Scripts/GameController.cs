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

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject roundEndPanel;
    [SerializeField] private GameObject endGamePanel;

    [Header("Words")]
    [SerializeField] private TMP_Text searchingWord;
    [SerializeField] private TMP_Text[] forbiddenWords;

    [Header("Values")]
    [SerializeField] private float currentRaund;
    [SerializeField] private float currentPass;
    [SerializeField] private float maxRaund;
    [SerializeField] private float maxPass;
    [SerializeField] private int score1;
    [SerializeField] private int score2;
    [SerializeField] private float totalTime;
    [SerializeField] private float currentTime;

    [Header("RoundEnd Panel")]
    [SerializeField] private Text team1Name;
    [SerializeField] private Text team2Name;
    [SerializeField] private Text team1ScoreText;
    [SerializeField] private Text team2ScoreText;

    [Header("EndGame Panel")]
    [SerializeField] private GameObject shining;
    [SerializeField] private Text winnerName;

    [Header("Others")]
    [SerializeField] private Image timerImage;
    [SerializeField] private TMP_Text passText;


    List<List<string>> wordList = new List<List<string>>();


    private void Start()
    {
        wordList = GetComponent<Words>().wordList;

        currentRaund = 1;
        score1 = 0;
        score2 = 0;

        if(currentRaund % 2== 0)
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team2Name");
            scoreText.text = "Score : " + score2.ToString();
        }
        else
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team1Name");
            scoreText.text = "Score : " + score1.ToString();
        }

        totalTime = PlayerPrefs.GetFloat("Time");
        maxRaund = PlayerPrefs.GetFloat("Round");
        maxPass = PlayerPrefs.GetFloat("Pass");

        currentTime = totalTime;
        currentPass = maxPass;

        team1Name.text = PlayerPrefs.GetString("Team1Name");
        team2Name.text = PlayerPrefs.GetString("Team2Name");

        passText.text = "(" + Mathf.Round(currentPass).ToString() + ")";

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
            if(currentRaund == maxRaund * 2)
            {
                endGamePanel.SetActive(true);
                shining.transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));

                winnerName.text = score1 > score2 ? PlayerPrefs.GetString("Team1Name") : PlayerPrefs.GetString("Team2Name");
            }
            else
            {
                team1ScoreText.text = score1.ToString();
                team2ScoreText.text = score2.ToString();

                roundEndPanel.SetActive(true);
                currentTime = 0;
            }


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


    public void ButtonResume()
    {
        currentTime = totalTime;
        currentRaund++;

        SetWords();

        currentPass = maxPass;

        passText.text = "(" + Mathf.Round(currentPass).ToString() + ")";

        if (currentRaund % 2 == 0)
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team2Name");
            scoreText.text = "Score : " + score2.ToString();
        }
        else
        {
            teamNameText.text = "Team : " + PlayerPrefs.GetString("Team1Name");
            scoreText.text = "Score : " + score1.ToString();
        }

        roundEndPanel.SetActive(false);

    }



    public void ButtonPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ButtonContinue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ButtonExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


    public void ButtonCorrect()
    {
        if (currentRaund % 2 == 0)
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
        if (currentRaund % 2 == 0)
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
        if(currentPass > 0)
        {
            currentPass--;
            passText.text = "(" + Mathf.Round(currentPass).ToString() + ")";

            SetWords();
        }
        else
        {
            currentPass = 0;
            passText.text = "(" + Mathf.Round(currentPass).ToString() + ")";
        }
    }


}
