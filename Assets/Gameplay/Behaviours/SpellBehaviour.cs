using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class SpellBehaviour : BaseBehaviour
    {
        [SerializeField] AreaOfEffectBehaviour areaOfEffect;

        List<ISpell> _spells;

        protected override void Awake()
        {
            base.Awake();
            _spells = GetComponents<ISpell>().ToList();
        }

        void Start()
        {
            Debug.Log("Começou");
            ExecuteSpell();
        }

        void ExecuteSpell()
        {
            Debug.Log("blabla");
            var targets = GetTargets();
            foreach (var target in targets)
            {
                Debug.Log("target");
                foreach (var spell in _spells)
                {
                    Debug.Log("apply spell");
                    spell.ApplySpell(target);
                }
            }
            Entity.Remove(1f);
        }

        IEnumerable<Entity> GetTargets()
        {
            return areaOfEffect.GetTargets();
        }
    }
}
