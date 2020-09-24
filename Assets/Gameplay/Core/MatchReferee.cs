using System.Collections.Generic;
using System.Linq;
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
            damageable.OnHealthChanged -= OnHealthChanged;
            damageable.OnDie -= OnDamageableDied;
        }
        public void Setup(GameActionFactory gameActionFactory, IEnumerable<IPlayer> players, IDamageable Castle)
        {
            GameActionFactory = gameActionFactory;
            Players = players.ToList();
            Castle.OnDie += OnCastleDied;
        }

        public void OnPlayerUsedCard(CardType card, Team team, int laneIdx)
        {
            var deployCardAction = GameActionFactory.CreateDeployCardAction(card, team, laneIdx);
            ActionsQueue.ScheduleAction(deployCardAction);
        }

        void Update() => ActionsQueue.Execute();
    }
}
