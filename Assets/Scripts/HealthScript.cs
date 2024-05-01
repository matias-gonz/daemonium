using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            if (_animator)
            {
                _animator.SetTrigger("Die");
                Destroy(gameObject, 0.4f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                Destroy(shot.gameObject);
            }
        }
    }
}