using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;
using UnityEngine.Assertions;

namespace Gameplay.Behaviours
{
    public class SlowEffectBehaviour : BaseBehaviour
    {
        
        [SerializeField] float slowFactor = 0.2f;

        MovementBehaviour movement;
        protected override void Awake()
        {
            base.Awake();
            movement = GetComponent<MovementBehaviour>();
            if(movement == null){
                return;
            }
            var newSpeed = movement.Speed * slowFactor;
            movement.ChangeSpeed(newSpeed);
        }
    }
}
