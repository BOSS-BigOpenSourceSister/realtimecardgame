using System.Collections.Generic;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class SplashDamageAttackBehaviour : AttackBehaviour
    {

        public float distanceSplashDamage = 3;

        private List<IDamageable> getEnemies()
        {
            var myTeam = Entity.Team;

            var enemies = GameObject.FindGameObjectsWithTag(myTeam.Opposite().GetTag());

            var damageables = new List<IDamageable>();

            foreach (var enemy in enemies)
            {
                if ((transform.position - enemy.transform.position).sqrMagnitude <= distanceSplashDamage * distanceSplashDamage)
                {
                    var damageable = enemy.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageables.Add(damageable);
                    }
                }

            }
            return damageables;

        }

        void Update()
        {
            if (!HasValidTarget)
            {
                return;
            }

            _attackTimer += Time.deltaTime;
            if (_attackTimer > CooldownInSeconds)
            {
                Attack();
                _attackTimer = 0f;
            }
        }

        void Attack()
        {
            Debug.Log("Ta no splash");
            var enemies = getEnemies();
            foreach (var enemy in enemies)
            {
                enemy.ScheduleDamage(10);
            }
        }


    }
}
