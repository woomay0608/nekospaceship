using UnityEngine;
using System;
using System.Collections;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    public enum GamePhase { Day, Night }

    [SerializeField]
    TextMeshProUGUI phaseText;
    [SerializeField]
    TextMeshProUGUI cycleText;

    [Header("Durations (seconds)")]
    public float dayLength = 30f;
    public float nightLength = 30f;
    public int cycleCount = 1;

    public GamePhase CurrentPhase { get; private set; } = GamePhase.Day;
    public float PhaseElapsed { get; private set; }   // 현재 페이즈 경과 시간
    public float PhaseDuration => CurrentPhase == GamePhase.Day ? dayLength : nightLength;

    public static event Action<GamePhase> OnPhaseChanged;

    Coroutine loop;

    void Start()
    {
        cycleText.text = "Day " + cycleCount;
        SetPhase(GamePhase.Day);
        loop = StartCoroutine(PhaseLoop());
    }

    IEnumerator PhaseLoop()
    {
        while (true)
        {
            PhaseElapsed = 0f;
            while (PhaseElapsed < PhaseDuration)
            {
                PhaseElapsed += Time.deltaTime;
                yield return null;
            }
            TogglePhase();
        }
    }

    void TogglePhase()
    {
        SetPhase(CurrentPhase == GamePhase.Day ? GamePhase.Night : GamePhase.Day);
    }

    public void SetPhase(GamePhase next)
    {
        if (CurrentPhase == GamePhase.Night)
        {
            ScoreSystem.Instance.AddScore(50);
            cycleCount++;
            cycleText.text = "Day " + cycleCount;
        }
        CurrentPhase = next;
        PhaseElapsed = 0f;
        OnPhaseChanged?.Invoke(CurrentPhase);
        phaseText.text = CurrentPhase.ToString();
        Debug.Log(CurrentPhase);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) SetPhase(GamePhase.Day);
        if (Input.GetKeyDown(KeyCode.N)) SetPhase(GamePhase.Night);
    }
}
