using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BaseGhost : MonoBehaviour
{
    protected NavMeshAgent _navMeshAgent;
    protected Transform _playerPos;
    public EGhostType GhostType;
    private bool _isNight = false;
    [Range(0f, 10f)] public float ReviveTime;


    [Range(1f, 10f)] public float TileSize;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    public void SetPlayer(Transform transform)
    {
        _playerPos = transform;
    }
    public void SetNight()
    {
        _isNight = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(DeathCorountine());
        }
    }

    public IEnumerator DeathCorountine()
    {
        gameObject.SetActive(false);
        ChangePos();
        yield return new WaitForSeconds(ReviveTime);
        gameObject.SetActive(true);
    }

    public void SetDay()
    {
        _isNight = false;
    }
    public virtual void ChasePlayer()
    {
        if (_isNight)
        {
            _navMeshAgent.isStopped = true;
        }
        else
        {
            _navMeshAgent.isStopped = false;
        }
    }

    public virtual void ChangePos() { }
}
