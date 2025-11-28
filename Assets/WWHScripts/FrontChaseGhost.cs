using UnityEngine;

public class FrontChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
        base.ChasePlayer();

        Vector2 PlayerPos = _playerPos.transform.position;
        Vector2 PlayerDir;

        Vector2 logicalPos = (PlayerPos - _lastPos) / Time.fixedDeltaTime;

        if(logicalPos.sqrMagnitude > 0.01f)
        {
            PlayerDir = logicalPos.normalized;
            _lastDir = PlayerDir;
        }
        else
        {
            PlayerDir = _lastDir;
        }
        _lastPos = PlayerPos;
        Vector2 playerOffset = 2f * TileSize * PlayerDir;


      
        _navMeshAgent.SetDestination(PlayerPos + playerOffset);
        


    }


}
