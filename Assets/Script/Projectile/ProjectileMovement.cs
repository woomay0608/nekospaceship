// ProjectileMovement.cs

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    private Rigidbody _rigidbody;

    private bool _hasFired = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            UnityEngine.Debug.LogError("RIGIDBODY 참조 실패!");
        }
    }

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (!_hasFired)
        {
            MoveForward();
            _hasFired = true;
        }
    }

    public void MoveForward()
    {
        if (_rigidbody != null)
        {
            Vector3 movementVector = transform.forward * _speed;
            _rigidbody.linearVelocity = movementVector;

            UnityEngine.Debug.Log($"[Projectile Debug] FixedUpdate 속도 설정 완료. Velocity: {movementVector}");
        }
    }
}