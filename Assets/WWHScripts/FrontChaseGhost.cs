using UnityEngine;

public class FrontChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
        base.ChasePlayer();

        Vector2 PlayerPos = _playerPos.position;
        //Vector2 PlayerDir;


        //Vector2 playerOffset = 2f * TileSize * PlayerDir;
        //pos¶û dir ÇÕÄ¡±â
        _navMeshAgent.SetDestination(PlayerPos);
        


    }
    public override void ChangePos()
    {
        base.ChangePos();
    }

}
