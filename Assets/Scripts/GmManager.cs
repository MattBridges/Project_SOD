using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GmManager : MonoBehaviour
{
    public int playerCredits = 100;
    public Text goldText;
    public Text waveText;
    public Text scoreText;
    public Text tileBonusText;
    public Text waveMultiplierText;
    public Text scoreUI;
    public Canvas gameOverScreen;
    public Canvas shopScreen;


    public int score;
    public int waveMultiplier;
    public int tileBonus;
    public int highScore;
    public bool gameOver;

    private PlayerStationManager station;
    private WaveSpawner waveSpawner;

    private void Start()
    {
        HideGameOverScreen();
        score = 0;
        gameOver = false;
        scoreUI.text = "Score: 0";
        station = FindObjectOfType<PlayerStationManager>();
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    public void AddCredits(int amt)
    {
        playerCredits += amt;
        UpdateGoldText();
    }
    public void RemoveCredits(int amt)
    {
        playerCredits -= amt;
        UpdateGoldText();
    }
    public void UpdateGoldText()
    {
        goldText.text = "Credits: " + playerCredits.ToString();
    }
    public void UpdateWaveText(int waveNumber)
    {
        waveText.text = "Wave " + waveNumber;
    }

    public void GameOver()
    {
        
        if(gameOver == false)
        {
            CalculateFinalScore();
            UpdateGameOverScreen();
            ShowGameOverScreen();
            waveSpawner.enabled = false;
        }
        gameOver = true;

    }

    public void CalculateFinalScore()
    {
        tileBonus = station.stationTiles.Count;
        waveMultiplier = waveSpawner.currentWaveIndex + 1;
        score = (score + tileBonus) * waveMultiplier;
    }

    public void IncreaseScore(int amt)
    {
        score += amt;
        scoreUI.text = "Score: " + score;
    }

    public void DecreaseScore(int amt)
    {
        score -= amt;
    }

    public void UpdateGameOverScreen()
    {
        tileBonusText.text = "Tile Bonus: " + tileBonus;
        waveMultiplierText.text = "Wave Multiplier: " + waveMultiplier;
        scoreText.text = "Score: " + score;
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.enabled = true;
    }

    public void HideGameOverScreen()
    {
        gameOverScreen.enabled = false;
    }

}
