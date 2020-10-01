# Como criar uma nova carta

## Implementar o script de ataque

Crie uma classe implementando o novo ataque, a classe pode herdar de `AttackBehaviour` (em Assets/Gameplay/Behaviours).

## Criar um prefab do novo personagem

Em (Assets/Gameplay/Core/Cards) estão os prefab dos personagens, se quiser criar uma copia, na interface do Unity, em 'Project' clique no prefab a ser copiado com o botão direito, vá para 'Create' e selecione a opção "Prefab Variant".

Para alterar a modelagem do personagem, entre no prefab criado, e adicione na "Hierarchy" o modelo do personagem, no arquivo já tem vários modelos criados, e é possível fazer pequenas alterações(cabeça, armas, formato do corpo etc) explorando a hierarquia destes.

Em 'Inspector', no componente 'Animator' podemos configurar a movimentação do personagem, se quiser adicionar efeitos visuais durante o ataque, adicione o script `TroopVisualEffects.cs` e em Hit Particles, escolha o efeito a ser utilizado.

Adicione ao prefab criado o script de ataque. Certifique-se também que os outros scripts necessários para o personagem estão adicionados ao prefab.

## Criar a carta

No arquivo `CardType.cs` (em Assets/Gameplay/Core/Cards), adicione no `enum` o nome da carta a ser criada.

Na interface do Unity, vá para o `CardPrefabsMap` (também em Assets/Gameplay/Core/Cards) e adicione ao `Card Prefab Dict` um item com sua nova carta selecionando o nome adicionado no `enum` e o prefab do personagem criado.

Ainda interface do Unity, vá para o `CardView` (em Assets/Gameplay/Behaviours/UI) e adicione no script, na variável `Card Sprites` um novo item, com o `enum` da sua nova carta e a imagem para a carta.

## Adicionar carta ao deck

Para sua carta ser adicionada ao deck de cartas, adicione ao script `PlayersDeck.cs` (em Assets/Gameplay/Core) na função `GetDummyDeck`, dentro do while a linha abaixo, trocando `NomeDaCarta` para o `enum` criado:

``` cs
cards.Add(CardType.NomeDaCarta);
```
