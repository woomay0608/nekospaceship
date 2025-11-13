
using UnityEngine;


public class BackChaseGhost : BaseGhost
{


    public override void ChasePlayer()
    {
        Vector2 PlayerPos = _playerPos.transform.position;
        Vector2 PlayerDir;

        Vector2 logicalPos = (PlayerPos - _lastPos) / Time.fixedDeltaTime;

        if (logicalPos.sqrMagnitude > 0.01f)
        {
            PlayerDir = logicalPos.normalized;
            _lastDir = PlayerDir;
        }
        else
        {
            PlayerDir = _lastDir;
        }
        _lastPos = PlayerPos;
        Vector2 playerOffset = -2f * TileSize * PlayerDir;
        Vector2 BackPos = PlayerPos + playerOffset;

        if (_navMeshAgent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            if (_curStatus == EAIStatus.Chase || _curStatus == EAIStatus.Attack)
            {
                _navMeshAgent.SetDestination(BackPos);

                if (_navMeshAgent.remainingDistance <= 2f) 
                {
                    ChangeStatus(EAIStatus.Home);
                }
            }
            else
            {
                if (_navMeshAgent.remainingDistance <= 2f) 
                {
                    ChangeStatus(EAIStatus.Chase);
                } 
            }
            
        }
           

    }



}
