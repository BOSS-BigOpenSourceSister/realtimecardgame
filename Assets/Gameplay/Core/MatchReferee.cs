using System.Collections.Generic;
using System.Linq;
using Gameplay.Core.Actions;
using Gameplay.Core.Cards;
using UnityEngine;

namespace Gameplay.Core
{
    public class MatchReferee : MonoBehaviour
    {
        GameActionFactory GameActionFactory { get; set; }

        GameActionsQueue ActionsQueue { get; } = new GameActionsQueue();

        List<IPlayer> Players { get; set; }

        public void Setup(GameActionFactory gameActionFactory, IEnumerable<IPlayer> players)
        {
            GameActionFactory = gameActionFactory;
            Players = players.ToList();
        }

        public void OnPlayerUsedCard(CardType card, Team team, int laneIdx, int count)
        {
            Debug.Log("Teste >> MatchReferee.OnPlayerUsedCard()");

            IGameAction cardAction = null;

            if (count > 1)
            {
                cardAction = GameActionFactory.CreateMultiDeployCardAction(card, team, laneIdx, count);
            }
            else
            {
                cardAction = GameActionFactory.CreateDeployCardAction(card, team, laneIdx);
            }

            ActionsQueue.ScheduleAction(cardAction);
        }

        void Update() => ActionsQueue.Execute();
    }
}
