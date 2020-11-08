using System.Collections.Generic;
using System.Linq;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay.Behaviours
{
    public class SlowSpell : BaseBehaviour, ISpell
    {
        public void ApplySpell(Entity target){
            var sc = target.gameObject.AddComponent<SlowEffectBehaviour>();
            Debug.Log($"Add slow effect behaviour to : {target.gameObject.name}");
        }
    }
}
