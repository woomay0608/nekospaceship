using UnityEngine;

public class RelativeChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {




        Vector2 PlayerPos = _playerPos.transform.position;
        Vector2 PlayerDir = _playerPos.GetRigidbody2D().linearVelocity;


        Vector2 PlayerOffset = 2f * TileSize * PlayerDir;
        Vector2 FrontPos = PlayerPos + PlayerOffset;

        Vector2 DirVector = FrontPos - (Vector2)transform.position;
        Vector2 TargetVector = DirVector * 2 + (Vector2)transform.position;

        _navMeshAgent.SetDestination(TargetVector);



    }

}
