using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Ball _Ball;

    [SerializeField]
    private Player _Player1;

    [SerializeField]
    private Player _Player2;

    [SerializeField]
    private UIManager _UIManager;


    private int _Score = 0;

    private const string BALL_PLAYERPREFS_KEY = "Ball";

    public static GameManager Instance = null;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        Init();
    }
    private void Init()
    {
        Subscribe();
        _UIManager.SetBestScoreText(PongPlayerPrefs.GetBestScore());
        _Ball.SetColor(PongPlayerPrefs.GetColor(BALL_PLAYERPREFS_KEY));
    }
    private void OnDestroy()
    {
        Unsubscribe();
    }
    private void Unsubscribe()
    {
        _Player1.OnScored -= OnScored;
        _Player2.OnScored -= OnScored;
        _Ball.OnFail -= OnFail;
    }
    private void Subscribe()
    {
        _Player1.OnScored += OnScored;
        _Player2.OnScored += OnScored;
        _Ball.OnFail += OnFail;
    }
    private void OnFail()
    {
        Restart();
    }
    private void OnScored(float currentPosition, float previousCollisionPosition)
    {
        _Score++;
        _UIManager.SetCurrentScoreText(_Score);
        _Ball.CorrectSpeedAndDirection(currentPosition, previousCollisionPosition);
    }
    internal void Restart()
    {
        if (CheckBestScore(_Score))
        {
            PongPlayerPrefs.SaveBestScore(_Score);
            _UIManager.SetBestScoreText(_Score);
        }
        ResetObjects();
    }
    private void ResetObjects()
    {
        _Player1.Reset();
        _Player2.Reset();
        _Ball.Reset();
        _Score = 0;
        _UIManager.SetCurrentScoreText(_Score);
    }
    internal void SetBallColor(Color color)
    {
        _Ball.SetColor(color);
        PongPlayerPrefs.SaveColor(color, BALL_PLAYERPREFS_KEY);
    }
    internal Color GetBallColor()
    {
        return _Ball.GetColor();
    }
    private bool CheckBestScore(int score)
    {
        return score > PongPlayerPrefs.GetBestScore();
    }
    internal void PauseGame()
    {
        Time.timeScale = 0;
    }
    internal void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
