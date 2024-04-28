using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector2 speed = new(5, 5);
    Vector2 movement;
    Rigidbody2D rigidbodyComponent;
    private Rigidbody2D _rigidbody2D;
    private WeaponScript _weapon;
    private HealthScript _health;

    void Start()
    {
        _weapon = GetComponent<WeaponScript>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<HealthScript>();
    }

    void Update()
    {
        movement = new Vector2(
            speed.x * Input.GetAxis("Horizontal"),
            speed.y * Input.GetAxis("Vertical")
        );

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            if (_weapon)
            {
                // false because the player is not an enemy
                _weapon.Attack(false);
            }
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
        if (!rigidbodyComponent) rigidbodyComponent = _rigidbody2D;

        rigidbodyComponent.velocity = movement;
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