using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Behaviours.Interfaces;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class ProjectileAttackBehaviour : MonoBehaviour, IAttacker
    {
        //Deixando visivel no Unity para linkar com o prefab flecha e dizer a posição que a flecha deverá ser instanciada
        [SerializeField] GameObject projectile;
        [SerializeField] Transform positionProjectile; //Posição que meu objeto será instanciado
        private GameObject _tempProjectile;

        private Rigidbody _rigidbody;
        // Força com que o Arco será lançado
        public float forceArrow = 10f;
        public float speed = 2;
        
        //Quando começar
        private void Awake()
        {
            Instantiated();
            _rigidbody = GetComponent<Rigidbody>();
        }

        //Se o personagem estiver na posição de ataque, instanciar o projétil!

        
        //Método de instanciar o projétil
        public void Instantiated()
        {
            _tempProjectile =
                Instantiate(projectile, positionProjectile.position, Quaternion.identity);
        }
        
        //Método para lançar o projétil
        public void LaunchProjectile()
        {
            /* Tem que colocar true pra gravidade e false pra kinematic para a flecha ter gravidade e ir caindo quando
            lançada */
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            //Faz com que a flecha se mova pra frente
            _rigidbody.AddForce(forceArrow*speed*Vector3.forward);
        }

        public void Attack(IDamageable target)
        {
            throw new NotImplementedException();
        }

    }
}
