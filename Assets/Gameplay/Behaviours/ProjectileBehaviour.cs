using System;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        // [SerializeField] GameObject projectile;
        public Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        //Quando bater com o castelo a flechar ficar
        private void OnCollisionEnter(Collision other)
        {   
            // Flecha passa a ter velocidade zero
            rigidbody.velocity = Vector3.zero;
            // Para poder ficar para no lugar sem cair
            rigidbody.useGravity = false;
        }

    }
}