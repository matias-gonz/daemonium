using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 movement;
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y
        );
        _rigidbody2D.velocity = movement;
    }
}
