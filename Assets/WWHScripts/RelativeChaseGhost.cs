using UnityEngine;

public class RelativeChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {


        base.ChasePlayer(); 

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
        Vector2 playerOffset = 2f * TileSize * PlayerDir;
        
        Vector2 FrontPos = PlayerPos + playerOffset;

        Vector2 DirVector = FrontPos - (Vector2)transform.position;
        Vector2 TargetVector = DirVector *2;

        _navMeshAgent.SetDestination(TargetVector);



    }

}
