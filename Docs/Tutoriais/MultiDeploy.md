# Documentação

1. Criar um novo tipo de carta no arquivo [CardType.cs](/Assets/Gameplay/Core/Cards/CardType.cs);
```Csharp
namespace Gameplay.Core.Cards
{
    public enum CardType
    {
        Warrior,
        //Novo tipo adicionado
        MultiWarrior, 
    }
}
```

2. No unity criar um novo prefab de personagem na pasta /Assets/Gameplay/Core/Cards (sugestão: copiar um prefab de um personagem existente);
3. Adicionar ao prefab um componente new Script chamado [MultiDeployBehaviour.cs](/Assets/Gameplay/Behaviours/MultiDeployBehaviour.cs);

```Csharp
namespace Gameplay.Behaviours
{
    public class MultiDeployBehaviour : BaseBehaviour
    {
        //Count representa a quantidade de personagens que irá à arena ao arrastar a carta.
        public int count = 1; 
    }
}
```
4. No script [Deployer.cs](/Assets/Gameplay/Core/Deployer.cs) existente, checar a quantidade de personagens que devem ser colocados na arena; 

```Csharp
 public Entity DeployCard(CardType cardType, Team team, int laneIdx)
        {
            var card = GameObjectFactory.CreateCard(cardType, team);
            
            var lane = Arena.Lanes[laneIdx];
            lane.AddEntity(card, team);

            var damageable = card.GetComponent<IDamageable>();
            
            if (damageable != null)
            {
                GameplayHUD.CreateHealthBar(damageable, team, card.transform);
            }

            var behaviour = card.GetComponent<MultiDeployBehaviour>();

            for (var i = 0; i < behaviour.count - 1; i++)
            {
                var additionalCard = GameObjectFactory.CreateCard(cardType, team);
                lane.AddEntity(additionalCard, team);
                
                if (damageable != null)
                {
                    GameplayHUD.CreateHealthBar(damageable, team, additionalCard.transform);
                }
            }

            return card;
        }
```
5. No Unity, acessar a pasta /Assets/Gameplay/Core/Cards e no CardPrefabsMap.prefab ir em Inspector na aba Card Prefab Map (Script) em Card Prefab Dict e associar o novo tipo (Multi Warrior) ao prefab;
o prefab
6. No Unity, acessar a pasta /Assets/Gameplay/Behaviours/UI/CardView e no CardView.prefab ir em Inspector na aba Card View (Script) em Card Sprites e associar o novo tipo (Multi Warrior) a uma imagem;




