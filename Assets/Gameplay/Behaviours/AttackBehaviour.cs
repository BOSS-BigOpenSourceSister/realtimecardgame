﻿using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay.Behaviours
{
    public class AttackBehaviour : BaseBehaviour
    {
        [SerializeField] int damage = 10;

        const int CooldownInSeconds = 1;

        List<IAttacker> _attackers;

        ColliderBehaviour _collider;

        IDamageable CurrentTarget { get; set; }

        public bool IsAttacking => HasValidTarget;

        bool HasValidTarget => CurrentTarget != null;

        float _attackTimer = 0;

        public float distanceSplashDamage = 3;
        private List<IDamageable> getEnemies()
        {
            var myTeam = Entity.Team;
            var enemyTeam = "";

            switch (myTeam)
            {
                case Team.Home:
                    enemyTeam = "Visitor";
                    break;
                case Team.Visitor:
                    enemyTeam = "Home";
                    break;
                default:
                    break;
            }

            var enemies = GameObject.FindGameObjectsWithTag(enemyTeam);

            var damageables = new List<IDamageable>();

            foreach (var enemy in enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) <= distanceSplashDamage)
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

        protected override void Awake()
        {
            base.Awake();
            _attackers = GetComponents<IAttacker>().ToList();
            _collider = GetComponent<ColliderBehaviour>();
            _collider.OnAddCollider += OnAddCollider;
            _collider.OnRemoveCollider += OnRemoveCollider;
        }

        void OnDestroy()
        {
            _collider.OnAddCollider -= OnAddCollider;
            _collider.OnRemoveCollider -= OnRemoveCollider;
        }

        void OnAddCollider(GameObject target)
        {
            var myTeam = Entity.Team;
            var opponents = _collider.GetCollidingObjects(myTeam.Opposite());
            if (opponents.Any())
            {
                ChooseTarget();
            }
        }

        void OnRemoveCollider(GameObject target) {}

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
            Assert.IsTrue(HasValidTarget, message: "Attack should only be called with a valid target");
            // CurrentTarget.ScheduleDamage(damage);
            var enemies = getEnemies();
            foreach (var enemy in enemies)
            {
                enemy.ScheduleDamage(damage);

            }
            // _attackers.ForEach(action: attacker => attacker.Attack(CurrentTarget));
        }

        void ChooseTarget()
        {
            if (HasValidTarget)
            {
                return;
            }

            var myTeam = Entity.Team;
            var opponents = _collider.GetCollidingObjects(myTeam.Opposite());
            foreach (var candidate in opponents)
            {
                var damageable = candidate.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    SetTarget(damageable);
                    return;
                }
            }            
        }

        void SetTarget(IDamageable damageable)
        {
            CurrentTarget = damageable;
            CurrentTarget.OnDie += OnTargetDied;
            _attackTimer = 0;
        }

        void ResetTarget()
        {
            CurrentTarget = null;
        }

        void OnTargetDied(IDamageable damageable)
        {
            damageable.OnDie -= OnTargetDied;
            ResetTarget();
        }
    }
}
