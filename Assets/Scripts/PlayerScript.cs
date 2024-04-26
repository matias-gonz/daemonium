using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector2 speed = new Vector2(5, 5);
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
            speed.x * Input.GetAxis("Horizontal"),
            speed.y * Input.GetAxis("Vertical")
        );
    }

    void FixedUpdate()
    {
        if (!rigidbodyComponent) rigidbodyComponent = _rigidbody2D;

        rigidbodyComponent.velocity = movement;
    }
}