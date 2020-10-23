using System;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;
using Object = System.Object;

namespace Gameplay.Behaviours
{
    public class ProjectileAttackBehaviour : BaseBehaviour, IAttacker
    {
        //Deixando visivel no Unity para linkar com o prefab flecha e dizer a posição que a flecha deverá ser instanciada
        [SerializeField] GameObject projectile;
        [SerializeField] Transform positionProjectile; //Posição que meu objeto será instanciado

        private ProjectileBehaviour _arrow;

        // Força com que o Arco será lançado
        public float forceArrow = 10f;
        // Velocidade do Arco
        public float speed = 2;


        //Se o personagem estiver na posição de ataque, instanciar o projétil!
       

        //Método de instanciar o projétil
        
        
        //Método para lançar o projétil
        // public void LaunchProjectile()
        // {
        //     /* Tem que colocar true pra gravidade e false pra kinematic para a flecha ter gravidade e ir caindo quando
        //     lançada */
        //     _arrow.rigidbody.isKinematic = false;
        //     _arrow.rigidbody.useGravity = true;
        //     //Faz com que a flecha se mova pra frente
        //     _arrow.rigidbody.AddForce(forceArrow*speed*(Vector3.forward));
        // }

        public void SetProjectileTime(ProjectileBehaviour projectileArrow, Team team)
        {
            projectileArrow.Entity.Team = team;
        }
        
        // ????????
        public void Attack(IDamageable target)
        {
            Debug.Log("Entramos");
            var projectileArrow = Instantiate(projectile, projectile.transform.position, Quaternion.Euler(new Vector3(0, 90, 0)));
            var projectileBehaviour = projectileArrow.GetComponent<ProjectileBehaviour>();
            SetProjectileTime(projectileBehaviour, Entity.Team);
        }

    }
}
