using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    private WeaponScript _weapon;
    
    void Start()
    {
        _weapon = GetComponentInChildren<WeaponScript>();
    }

    void Update()
    {
        if(_weapon && _weapon.CanAttack)
        {
            _weapon.Attack(true);
        }
    }
}
