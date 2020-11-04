using Gameplay.Behaviours.Interfaces;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class AttackDamageBehaviour : BaseBehaviour, IAttacker
    {
        [SerializeField] int damage = 10;

        public void Attack(IDamageable target)
        {
            target.ScheduleDamage(damage);
        }
    }
}
