using System;
using TMPro;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject ingamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI startHighscoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endgameScoreText;
    [SerializeField] private TextMeshProUGUI endgameHighscoreText;

    private float score = 0f;
    private bool started = false;
    private bool ended = false;

    private Player player;
    
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        startHighscoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                StartGame();
            }
        }
        else if (started)
        {
            score += Time.deltaTime * player.GetSpeed();
            int roundedScore = (int)Math.Round(score);
            scoreText.text = roundedScore.ToString();
        }
        
        if (ended)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }

    private void StartGame()
    {
        startPanel.SetActive(false);
        
        Time.timeScale = 1;
        ingamePanel.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        ended = true;
        ingamePanel.SetActive(false);

        int roundedScore = (int)Math.Round(score);
        int highscore = HandleHighscore(roundedScore);
        endgameHighscoreText.text = highscore.ToString();
        endgameScoreText.text = roundedScore.ToString();
        gameOverPanel.SetActive(true);
    }

    private int HandleHighscore(int newScore)
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        if (newScore > highscore)
        {
            highscore = newScore;
        }
        PlayerPrefs.SetInt("highscore", highscore);
        return highscore;
    }
}
