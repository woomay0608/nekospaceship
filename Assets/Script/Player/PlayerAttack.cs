using System.Collections;
using UnityEngine;

public class AutoProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _fireRate = 3.0f;
    [SerializeField] private float _projectileSpeed = 15f;
    [SerializeField] private Transform _firePoint;

    private bool _isFiring = false;

    void Start()
    {
        StartAutoFire();
    }

    public void StartAutoFire()
    {
        if (!_isFiring)
        {
            _isFiring = true;
            StartCoroutine(FireRoutine());
        }
    }

    private IEnumerator FireRoutine()
    {
        while (_isFiring)
        {
            LaunchProjectile();
            yield return new WaitForSeconds(_fireRate);
        }
    }

    private void LaunchProjectile()
    {
        if (_projectilePrefab == null)
        {
            return;
        }

        Transform spawnPoint = _firePoint != null ? _firePoint : transform;

        GameObject newProjectile = Instantiate(_projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        Vector2 fireDirection = spawnPoint.up;

        Rigidbody2D rig = newProjectile.GetComponent<Rigidbody2D>();

        if (rig != null)
        {
            rig.gravityScale = 0f;
            rig.linearVelocity = fireDirection * _projectileSpeed;
        }
    }
}