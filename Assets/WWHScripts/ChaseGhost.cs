
public class ChaseGhost : BaseGhost
{
    public override void ChasePlayer()
    {
       

        _navMeshAgent.SetDestination(_playerPos.transform.position);

    }

}
