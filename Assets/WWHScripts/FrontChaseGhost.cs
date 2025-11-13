using UnityEngine;

public class FrontChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
        

        if (_navMeshAgent.remainingDistance <= 2.5f)
        {
            ChangeStatus(EAIStatus.Attack);
        }

        Vector2 PlayerPos = _playerPos.transform.position;
        Vector2 PlayerDir = _playerPos.GetRigidbody2D().linearVelocity;


        Vector2 playerOffset = 2f * TileSize * PlayerDir;
        //pos¶û dir ÇÕÄ¡±â
        _navMeshAgent.SetDestination(PlayerPos + playerOffset);
        


    }


}
