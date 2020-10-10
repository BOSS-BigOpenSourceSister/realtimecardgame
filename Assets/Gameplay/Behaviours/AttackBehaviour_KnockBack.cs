using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay.Behaviours
{
    public class AttackBehaviour_KnockBack : AttackBehaviour
    {


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
            CurrentTarget.ScheduleDamage(damage);
            _attackers.ForEach(action: attacker => attacker.Attack(CurrentTarget));
            /*adicionar o transform position ou coisa parecida no myTeam.Opposite() */
        }


    }
}
