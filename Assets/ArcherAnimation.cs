using Gameplay.Behaviours;
using UnityEngine;

public class ArcherAnimation : MonoBehaviour
{
    private ProjectileAttackBehaviour projectileAttackBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        projectileAttackBehaviour = gameObject.GetComponentInParent<ProjectileAttackBehaviour>();
    }

 
    public void InstantiateArrow()
    {
        projectileAttackBehaviour.Instantiated();
    }
}