using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gameplay.Behaviours.Interfaces;
using Gameplay.Behaviours.UI;
using Gameplay.Core.Cards;
using UnityEngine.Assertions;
using Gameplay.Core;


public class ShowHeathBar : MonoBehaviour
{
    [SerializeField] GameplayHUD gameplayHUD;

    // GameObjectFactory GameObjectFactory { get; }

    // Start is called before the first frame update
    public IDamageable damageable;
    public Team team = Team.Visitor;
    public Transform attachPoint;
    void Start()
    {
        damageable = GetComponent<IDamageable>();
        attachPoint = transform;
        Debug.Log(Team.Visitor);
        if (damageable != null && attachPoint != null && team != null)
        {
            Debug.Log(gameplayHUD == null);
            gameplayHUD.CreateHealthBar(damageable, team, attachPoint );
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
