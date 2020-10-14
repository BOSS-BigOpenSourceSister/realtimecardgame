using UnityEngine;

namespace Gameplay.Behaviours
{
    public class ManaBehaviour : BaseBehaviour
    {
        [SerializeField] int cardCost = 2;

        public int CardCost => cardCost;
    }
}
