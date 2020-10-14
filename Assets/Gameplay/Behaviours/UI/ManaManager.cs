using UnityEngine;
using Gameplay.Behaviours;


public class ManaManager
{
    public static int manaMaxValue = 12;
    public int mana = manaMaxValue;
    public float timeRemaining = 10;

    public void UseCard(ManaBehaviour manaBehaviour) {
        mana -= manaBehaviour.CardCost;
    }

    public void AddMana()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } 
        else 
        {
            timeRemaining = 10;
            if (mana < manaMaxValue)
            {
                mana += 1;
                Debug.Log("Update Mana: " + mana);
            }
        }
    }

    
}
