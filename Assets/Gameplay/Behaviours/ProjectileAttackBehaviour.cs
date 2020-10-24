using System;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;
using Object = System.Object;

namespace Gameplay.Behaviours
{
    /*
     * Classe: ProjectileAttackBehaviour
     * Responsabilidade: Instanciar a flecha e setar um time para o Arqueiro
     */
    public class ProjectileAttackBehaviour : BaseBehaviour
    {
        //Deixando visivel no Unity para linkar com o prefab flecha e dizer a posição que a flecha deverá ser instanciada
        [SerializeField] ProjectileBehaviour projectile;
        [SerializeField] Transform positionProjectile; //Posição que meu objeto será instanciado

        // public void Attack(IDamageable target)
        // {
        //     Debug.Log("Entramos");
        //     //Instantiated();
        //             
        // }
        
        void SetProjectileTime(ProjectileBehaviour projectileArrow, Team team)
        {
            projectileArrow.Entity.Team = team;
        }

        public void Instantiated()
        {
            var projectileArrow = Instantiate(projectile, positionProjectile);
                SetProjectileTime(projectileArrow, Entity.Team);
        }


    }
}
