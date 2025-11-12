using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BaseGhost : MonoBehaviour
{
    protected Animator _animator;
    protected NavMeshAgent _navMeshAgent;
    protected Transform _playerPos;
    public EGhostType GhostType;
    
    [Range(0f, 10f)] public float ReviveTime;
    [Range(1f, 10f)] public float TileSize;
    [SerializeField] public Vector3 RespawnPos;

    [SerializeField] EAIStatus _curStatus;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator =GetComponent<Animator>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("MoveX", _navMeshAgent.velocity.normalized.x);
       _animator.SetFloat("MoveY", _navMeshAgent.velocity.normalized.y);

        if (_curStatus == EAIStatus.Chase)
        {
            ChasePlayer();
        }
        else if (_curStatus == EAIStatus.Attack) 
        {
            AttackPlayer();
        }
        else
        {

        }
        
    }

    public void SetPlayer(Transform transform)
    {
        _playerPos = transform;
    }

    public void ChangeStatus(EAIStatus eAI)
    {
        _curStatus = eAI;

       if(_curStatus == EAIStatus.Chase || _curStatus == EAIStatus.Attack)
        {
            _navMeshAgent.isStopped = false;
            _animator.SetBool("IsRun", true);
        }
       else
        {
            _animator.SetBool("IsRun", false);
            _animator.SetTrigger("IsDeath");
            _navMeshAgent.isStopped = true;
        }
    }
    public void SetNight()
    {
        ChangeStatus(EAIStatus.Night);
    }
     public void SetDay()
    {
        ChangeStatus(EAIStatus.Chase);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    public IEnumerator DeathCorountine()
    {
        gameObject.SetActive(false);
        ChangePos();
        yield return new WaitForSeconds(ReviveTime);
        gameObject.SetActive(true);
    }

   
    public virtual void ChasePlayer()
    {
        if (_navMeshAgent.remainingDistance <= 2.5f && EGhostType.Chase != GhostType)
        {
            ChangeStatus(EAIStatus.Attack);
        }
    }

    public void AttackPlayer()
    {
        if(_playerPos != null)
        _navMeshAgent.SetDestination(_playerPos.position);

        if (_navMeshAgent.remainingDistance >= 2.5f)
        {
            ChangeStatus(EAIStatus.Chase);
        }

    }
    public void ChangePos()
    {
        if (RespawnPos != null)
        {
            transform.position = RespawnPos;
        }

    } 


}
