using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    DayNightSystem phase;

    void Start()
    {
        phase = FindObjectOfType<DayNightSystem>();
    }

    void Update()
    {
        bool isNight = phase != null && phase.CurrentPhase == DayNightSystem.GamePhase.Night;
        // K: 적 처치
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isNight)
            {
                ScoreSystem.ReportEnemyKilled();
                Debug.Log("[Test] Enemy killed → +score");
            }
            else
            {
                Debug.Log("[Test] Enemy became wall");
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            ScoreSystem.ReportGetPoint();
            Debug.Log("[Test] Get Points → +score");
        }

        // H: 플레이어 피격
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isNight)
            {
                Debug.Log("[Test] Player hit by Projectiles");
            }
            else
            {
                Debug.Log("[Test] Player hit by Enemy");
            }
        }
    }
}
