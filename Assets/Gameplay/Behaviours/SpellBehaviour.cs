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
            ExecuteSpell();
        }

        void ExecuteSpell()
        {
            var targets = GetTargets();
            foreach (var target in targets)
            {
                foreach (var spell in _spells)
                {
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
