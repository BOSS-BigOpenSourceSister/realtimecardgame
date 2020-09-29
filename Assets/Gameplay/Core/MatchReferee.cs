using System.Collections.Generic;
using System.Linq;
using System;
using Gameplay.Core.Actions;
using Gameplay.Core.Cards;
using UnityEngine;
using Gameplay.Behaviours.Interfaces;


namespace Gameplay.Core
{
    public class MatchReferee : MonoBehaviour
    {
        GameActionFactory GameActionFactory { get; set; }

        GameActionsQueue ActionsQueue { get; } = new GameActionsQueue();

        List<IPlayer> Players { get; set; }

        void OnCastleDied(IDamageable damageable)
        {
            Debug.Log("A PARTIDA ACABOU!");
            damageable.OnDie -= OnCastleDied;
            OnGameOver?.Invoke();
        }

        public event Action OnGameOver;
        
        public void Setup(GameActionFactory gameActionFactory, IEnumerable<IPlayer> players, IDamageable castleBlue, IDamageable castleRed)
        {
            GameActionFactory = gameActionFactory;
            Players = players.ToList();
            castleBlue.OnDie += OnCastleDied;
            castleRed.OnDie += OnCastleDied;
        }

        public void OnPlayerUsedCard(CardType card, Team team, int laneIdx)
        {
            var deployCardAction = GameActionFactory.CreateDeployCardAction(card, team, laneIdx);
            ActionsQueue.ScheduleAction(deployCardAction);
        }

        void Update() => ActionsQueue.Execute();
    }
}
