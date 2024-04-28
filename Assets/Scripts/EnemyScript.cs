using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool hasSpawn;
    private MoveScript _moveScript;
    private WeaponScript _weapon;
    private Collider2D _collider;
    private SpriteRenderer _renderer;


    void Awake()
    {
        _weapon = GetComponentInChildren<WeaponScript>();
        _moveScript = GetComponent<MoveScript>();
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        hasSpawn = false;
        _collider.enabled = false;
        _renderer.enabled = false;
        _moveScript.enabled = false;
        _weapon.enabled = false;
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
            _weapon.Attack(true);
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
        _moveScript.enabled = true;
        _weapon.enabled = true;
    }
}