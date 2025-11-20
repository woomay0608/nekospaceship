
using UnityEngine;
using UnityEngine.AI;


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

        Debug.Log(_navMeshAgent.pathStatus);

        NavMeshHit hit;

        if(NavMesh.SamplePosition(BackPos,out hit,1f, NavMesh.AllAreas ))
        {
           
             if (_curStatus == EAIStatus.Chase || _curStatus == EAIStatus.Attack)
            {
                _navMeshAgent.SetDestination(BackPos);

               

                if (_navMeshAgent.remainingDistance <= 2f) //겹치는 부분이 생김 수정바람
                {
                    Debug.Log("To Chase Player:" + _navMeshAgent.remainingDistance);
                    ChangeStatus(EAIStatus.Home);
                    _navMeshAgent.SetDestination(RespawnPos);
                }
            }
            else
            {
                if (_navMeshAgent.remainingDistance <= 3f)
                {
                    Debug.Log("To Home:" +_navMeshAgent.remainingDistance);
                    ChangeStatus(EAIStatus.Chase);
                }
            }
        }
        else
        {
            Debug.Log("Player Direct Chase");
            _navMeshAgent.SetDestination(_playerPos.transform.position);
        }
       

    }
       


            
           
           

    }




