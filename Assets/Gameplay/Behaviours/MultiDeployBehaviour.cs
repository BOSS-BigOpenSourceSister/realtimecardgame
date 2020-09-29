using UnityEngine;

namespace Gameplay.Behaviours
{
    public class MultiDeployBehaviour : BaseBehaviour
    {
        [SerializeField] int count = 1;

        public int Count => count;
    }
}