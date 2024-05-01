using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private WeaponScript _weapon;
    private Collider2D _collider;
    private SpriteRenderer _renderer;


    void Awake()
    {
        _weapon = GetComponentInChildren<WeaponScript>();
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        hasSpawn = false;
        _collider.enabled = false;
        _renderer.enabled = false;
        if (_weapon)
        {
            _weapon.enabled = false;
        }
    }

    void Update()
    {
        if (!hasSpawn)
        {
            if (_renderer.IsVisibleFrom(Camera.main))
            {
                Spawn();
            }

            return;
        }
        
        if (_weapon && _weapon.CanAttack)
        {
            _weapon.Attack(true, null);
        }
        
        if (_renderer.IsVisibleFrom(Camera.main) == false)
        {
            Destroy(gameObject);
        }
    }
    
    private void Spawn()
    {
        hasSpawn = true;
        _collider.enabled = true;
        _renderer.enabled = true;
        if (_weapon)
        {
            _weapon.enabled = true;
        }
    }
}