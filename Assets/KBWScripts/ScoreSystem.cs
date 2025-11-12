using UnityEngine;
using System;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    [Header("Scoring")]
    public int scorePerKill = 1;// 적 처치 가산
    public int scorePerPoint = 1;
    public int totalScore = 0;


    public static ScoreSystem Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        scoreText.text = "Score : 0";
    }

    public static void ReportEnemyKilled()
    {
        if (Instance == null) return;
        Instance.AddScore(Instance.scorePerKill);
    }

    public static void ReportGetPoint()
    {
        if (Instance == null) return;
        Instance.AddScore(Instance.scorePerPoint);
    }

    public void AddScore(int point)
    {
        totalScore += point;
        Debug.Log("Total Score: " +  totalScore);
        scoreText.text = "Score : " + totalScore;
    }
}
