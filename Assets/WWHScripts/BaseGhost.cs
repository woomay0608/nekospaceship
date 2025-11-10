using UnityEngine;
using UnityEngine.AI;

public class BaseGhost : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _playerPos;
    public EGhostType GhostType;
    void Start()
    {
        GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void SetPlayer(Transform transform)
    {
        _playerPos = transform;
    }

    public virtual void ChasePlayer()
    {

    }
}
