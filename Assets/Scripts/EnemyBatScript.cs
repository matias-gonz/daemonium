using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBatScript : MonoBehaviour
{
    Vector2 speed = new Vector2(5, 5);
    Vector2 direction = new Vector2(-1, 0);
    Vector2 movement;
    Rigidbody2D rigidbodyComponent;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y
        );
    }
    
    void FixedUpdate()
    {
        if (!rigidbodyComponent) rigidbodyComponent = _rigidbody2D;
        rigidbodyComponent.velocity = movement;
    }
}
