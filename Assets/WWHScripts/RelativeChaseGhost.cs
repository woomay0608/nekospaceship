

using UnityEngine;

public class RelativeChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
        base.ChasePlayer();

        //Vector2 PlayerPos = _playerPos.position;
        //Vector2 PlayerDir;


        //Vector2 PlayerOffset = 2f * TileSize * PlayerDir;
        //Vector2 FrontPos  = PlayerDir + playerOffset;

        //Vector2 DirVector = FrontPos + transform.position;
        //Vector2 TargetVector = DirVector * 2 + transform.position;

        // _navMeshAgent.SetDestination(TargetVector);



    }
}
