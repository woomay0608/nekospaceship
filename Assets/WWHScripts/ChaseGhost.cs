using UnityEngine;

public class ChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
        base.ChasePlayer();

        _navMeshAgent.SetDestination(_playerPos.transform.position);

    }
}
