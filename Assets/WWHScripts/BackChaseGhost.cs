using UnityEngine;

public class BackChaseGhost : BaseGhost
{

    bool _isRun;
    public override void ChasePlayer()
    {
        base.ChasePlayer();

        //Vector2 PlayerPos = _playerPos.position;
        //Vector2 PlayerDir;


        //Vector2 PlayerOffset = -2f * TileSize * PlayerDir;
        //Vector2 BackPos  = PlayerDir + playerOffset;

        //if(agent.remainingDistance <= agent.stoppingDistance && !isRun) _isRun = true; agent.setDestination(BackPos);
        //else 집으로 돌아가요 내부에서 집에 도착했으면 isRun = false;

    }

    public override void ChangePos()
    {
        base.ChangePos();
    }
}
