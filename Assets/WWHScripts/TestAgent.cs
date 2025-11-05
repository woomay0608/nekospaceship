using UnityEngine;
using UnityEngine.AI;

public class TestAgent : MonoBehaviour
{

    public Transform Des;
    NavMeshAgent meshAgent;
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.SetDestination(Des.position);

    }

  
}
