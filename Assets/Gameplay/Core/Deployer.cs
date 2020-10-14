using Gameplay.Behaviours;
using Gameplay.Behaviours.Interfaces;
using Gameplay.Behaviours.UI;
using Gameplay.Core.Cards;
using UnityEngine.Assertions;

using UnityEngine;

namespace Gameplay.Core
{
    public class Deployer
    {
        GameObjectFactory GameObjectFactory { get; }

        Arena Arena { get; }

        GameplayHUD GameplayHUD { get; }

        public Deployer(GameObjectFactory gameObjectFactory, Arena arena, GameplayHUD gameplayHUD)
        {
            GameObjectFactory = gameObjectFactory;
            Arena = arena;
            GameplayHUD = gameplayHUD;
        }

        public Entity DeployCard(CardType cardType, Team team, int laneIdx, IPlayer player)
        {
            var card = GameObjectFactory.CreateCard(cardType, team);

            var lane = Arena.Lanes[laneIdx];

            var damageable = card.GetComponent<IDamageable>();

            AddCard(card, lane, team, damageable);

            var multiDeployBehaviour = card.GetComponent<MultiDeployBehaviour>();
            var manaBehaviour = card.GetComponent<ManaBehaviour>();

            if (multiDeployBehaviour != null)
            {
                for (var i = 0; i < multiDeployBehaviour.AdditionalDeployCount - 1; i++)
                {
                    var additionalCard = GameObjectFactory.CreateCard(cardType, team);

                    AddCard(additionalCard, lane, team, damageable);
                }
            }

            if (manaBehaviour != null )
            {
                Debug.Log("Players Mana: " + player.Mana.mana);
                player.Mana.UseCard(manaBehaviour);
                Debug.Log("Cards Mana: " + manaBehaviour.CardCost);
            }

            return card;
        }

        private void AddCard(Entity card, Lane lane, Team team, IDamageable damageable)
        {
            lane.AddEntity(card, team);

            if (damageable != null)
            {
                GameplayHUD.CreateHealthBar(damageable, team, card.transform);
            }
        }
    }
}
