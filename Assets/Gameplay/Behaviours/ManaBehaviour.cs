using UnityEngine;

namespace Gameplay.Behaviours
{
    public class ManaBehaviour : BaseBehaviour
    {
        [SerializeField] int cardManaValue= 2;

        public int CardManaValue => cardManaValue;
    }
}
