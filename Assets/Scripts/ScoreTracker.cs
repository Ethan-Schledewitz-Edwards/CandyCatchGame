using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker Instance;

    private int currentScore;

    [SerializeField] CandySpawner _candySpawner;
    [SerializeField] PlayerMovement _player;

    private void Awake()
    {
        Instance = this;
    }

    public void AddToScore(int amount)
    {
        currentScore += amount;
        HUDManager.instance.SetScoreText(currentScore.ToString());
    }

    //
    public void FinishGame()
    {
        InputManager.UIMode();
        HUDManager.instance.ShowFinalScore(currentScore);
        _player.StopMovement();
    }

    //This method resets the game
    public void ResetGame()
    {
        currentScore = 0;
        InputManager.GameMode();
        _candySpawner.ToggleCandySpawining(true);
    }
}
