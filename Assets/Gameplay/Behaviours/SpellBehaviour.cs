using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class SpellBehaviour : BaseBehaviour
    {   
        [SerializeField] float delay = 0.5f;
        [SerializeField] AreaOfEffectBehaviour areaOfEffect;

        List<ISpell> _spells;

        float _timer;

        protected override void Awake()
        {
            base.Awake();
            _spells = GetComponents<ISpell>().ToList();
        }

        bool _executed;

        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= delay && !_executed)
            {
                ExecuteSpell();
                _executed = true;
            }            
        }

        void ExecuteSpell()
        {
            Debug.Log("blabla");
            var targets = GetTargets();
            foreach (var target in targets)
            {
                Debug.Log($"target: {target.gameObject.name}");
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
