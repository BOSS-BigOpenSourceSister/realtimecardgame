using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Behaviours.Interfaces;
using UnityEngine;

public class ProjectileAttackBehaviour : IAttacker
{
    // Start is called before the first frame update
    void Start()
    {
        [SerializeField] GameObject Projectile;

    }

    void Awake()
    {
        
        Projectile.Add((GameObject)Instantiate(Projectile, Projectile.transform.position, Projectile.transform.rotation));

    }


    public void Attack(IDamageable target)
    {
        throw new NotImplementedException();
    }
}
