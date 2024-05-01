using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new(5, 5);
    public KeyCode[] movementKeys = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    public KeyCode shootKey = KeyCode.Space;

    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private WeaponScript _weapon;
    private HealthScript _health;
    private Animator _animator;

    void Start()
    {
        _weapon = GetComponent<WeaponScript>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<HealthScript>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_health.hp <= 0)
        {
            return;
        }
        
        _movement = new Vector2(0, 0);
        if (Input.GetKey(movementKeys[0]))
        {
            _movement.y = speed.y;
        }
        else if (Input.GetKey(movementKeys[2]))
        {
            _movement.y = -speed.y;
        }

        if (Input.GetKey(movementKeys[3]))
        {
            _movement.x = speed.x;
        }
        else if (Input.GetKey(movementKeys[1]))
        {
            _movement.x = -speed.x;
        }

        bool shoot = Input.GetKey(shootKey);

        if (shoot && _weapon)
        {
            // false because the player is not an enemy
            _weapon.Attack(false, _animator);
        }

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = _movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthScript enemy = collision.gameObject.GetComponent<HealthScript>();

        if (enemy != null && enemy.isEnemy)
        {
            enemy.Damage(enemy.hp);
            _health.Damage(_health.hp);
        }
    }
}