
using UnityEngine;


public class BackChaseGhost : BaseGhost
{

 
    public override void ChasePlayer()
    {


        Vector2 PlayerPos = _playerPos.transform.position;
        Vector2 PlayerDir = _playerPos.GetRigidbody2D().linearVelocity;


        Vector2 PlayerOffset = -2f * TileSize * PlayerDir;
        Vector2 BackPos = PlayerPos + PlayerOffset;



        if (_curStatus == EAIStatus.Chase || _curStatus == EAIStatus.Attack || _curStatus == EAIStatus.Night)
        {

            _navMeshAgent.SetDestination(BackPos);
            if (_navMeshAgent.remainingDistance <= 3f)
            {
                ChangeStatus(EAIStatus.Home);
            }

        }
        else
        {
            Debug.Log(RespawnPos.ToString());
            _navMeshAgent.SetDestination(RespawnPos);
            if(_navMeshAgent.remainingDistance < 0.5f)
            {
                ChangeStatus(EAIStatus.Chase);

            }
        }


    }


}
