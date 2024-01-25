using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewShooting : MonoBehaviour
{
    private CharacterController _controller;
    private ProjectileManager _projectileManager;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        
        _controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _projectileManager = ProjectileManager.instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackStatsSetting attackData)
    {
           
        for (int i = 0; i < 1; i++)
        {
            CreateProjectile(attackData);
        }
        
    }

    private void CreateProjectile(AttackStatsSetting attackData)
    {
        _projectileManager.ShootBullet(
            projectileSpawnPosition.position,
            RotateVector2(_aimDirection),
            attackData);
    }

    private static Vector2 RotateVector2(Vector2 v)
    {
        return Quaternion.Euler(0, 0, 0) * v;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
