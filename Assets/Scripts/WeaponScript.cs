using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform shotPrefab;
    public float shootingRate = 0.5f;
    private float _shootCooldown;

    void Start()
    {
        _shootCooldown = 0f;
    }

    void Update()
    {
        if (_shootCooldown > 0)
        {
            _shootCooldown -= Time.deltaTime;
        }
    }

    public void Attack(bool isEnemy, Animator animator)
    {
        if (!CanAttack)
        {
            return;
        }

        if (animator)
        {
            animator.SetTrigger("Attack");
        }

        if (isEnemy)
        {
            _shootCooldown = Random.Range(0.2f, shootingRate);
        }
        else
        {
            _shootCooldown = shootingRate;
        }

        var shotTransform = Instantiate(shotPrefab) as Transform;
        shotTransform.position = transform.position;
        ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            shot.isEnemyShot = isEnemy;
        }

        MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
        if (move != null)
        {
            move.direction = this.transform.right;
        }
    }

    public bool CanAttack => _shootCooldown <= 0f;
}