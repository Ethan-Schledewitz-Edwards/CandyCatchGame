using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalscoreText;

    [Header("Rank Messages")]
    [SerializeField] private GameObject _sadness;
    [SerializeField] private GameObject _sugarRush;
    [SerializeField] private GameObject _halloween;
    [SerializeField] private GameObject _candyCraze;

    public enum rankType 
    { 
        None,
        Sadness,
        Sugarrush,
        Halloween,
        CandyCraze
    }


    private void Awake()
    {
        instance = this;
        SetScoreText("0");
        toggleFinalScore(false);
    }

    
    //Sets the score text to a string
    public void SetScoreText(string text)
    {
        _scoreText.text = text;
    }

    //Enables the final score object and sets its value
    public void ShowFinalScore(int finalScore)
    {
        toggleScoreCounter(false);
        _finalscoreText.gameObject.SetActive(enabled);
        _finalscoreText.text = "Your final score is " + finalScore;

        if (finalScore < 15)
            DisplayRankMessage(rankType.Sadness);
        else if (finalScore < 35 && finalScore > 15)
            DisplayRankMessage(rankType.Sugarrush);
        else if (finalScore < 50 && finalScore > 35)
            DisplayRankMessage(rankType.Halloween);
        else if (finalScore > 50)
            DisplayRankMessage(rankType.CandyCraze);
    }

    //Displays A rank message
    private void DisplayRankMessage(rankType ranking)
    {
        _sadness.SetActive(ranking == rankType.Sadness);
        _sugarRush.SetActive(ranking == rankType.Sugarrush);
        _halloween.SetActive(ranking == rankType.Halloween);
        _candyCraze.SetActive(ranking == rankType.CandyCraze);
    }

    //Toggles the score counters game object
    private void toggleScoreCounter(bool enabled)
    {
        _scoreText.gameObject.SetActive(enabled);
    }

    //Toggles the final score on and off
    private void toggleFinalScore(bool enabled)
    {
        _finalscoreText.gameObject.SetActive(enabled);
    }

    #region ButtonMethods
    public void ResetButton()
    {
        toggleFinalScore(false);
        toggleScoreCounter(true);
        SetScoreText("0");
        ScoreTracker.Instance.ResetGame();
    }

    #endregion
}
