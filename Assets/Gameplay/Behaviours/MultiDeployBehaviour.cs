using UnityEngine;

namespace Gameplay.Behaviours
{
    public class MultiDeployBehaviour : BaseBehaviour
    {
        [SerializeField] int additionalDeployCount= 2;

        public int AdditionalDeployCount => additionalDeployCount;
    }
}
