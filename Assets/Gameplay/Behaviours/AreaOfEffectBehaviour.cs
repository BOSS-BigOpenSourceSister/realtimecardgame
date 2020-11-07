using System.Collections.Generic;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class AreaOfEffectBehaviour : BaseBehaviour
    {
        [SerializeField] Team targetTeam;

        ColliderBehaviour _collider;

        protected override void Awake()
        {
            base.Awake();
            _collider = GetComponent<ColliderBehaviour>();
        }

        public List<Entity> GetTargets()
        {
            return _collider.GetCollidingObjects(targetTeam);
        }
    }
}
