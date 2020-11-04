using System;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class ProjectileBehaviour : BaseBehaviour
    {
        AttackBehaviour _attack;

        protected override void Awake()
        {
            base.Awake();
            _attack = GetComponent<AttackBehaviour>();
            _attack.onAttack += RemoveArrow;
        }
        
        void RemoveArrow()
        {
            _attack.onAttack -= RemoveArrow;
            Entity.Remove();
        }

    }
}