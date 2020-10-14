using UnityEngine;
using Gameplay.Behaviours;
using UnityEngine.UI;


public class ManaManager
{
    public static int manaMaxValue = 12;
    public int mana = 0;
    public float timeRemaining = 10;

    public void UseCard(ManaBehaviour manaBehaviour) {
        if (mana < manaBehaviour.CardCost)
        {
            ShowLabelManaWarning(true);
        }
        else
        {
            mana -= manaBehaviour.CardCost;

            if (mana < 0)
            {
                mana = 0;
            }

            ShowLabelManaWarning(false);
            UpdateLabelMana(mana);
        }
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

                UpdateLabelMana(mana);

                Debug.Log("Update Mana: " + mana);
            }
        }
    }

    public void UpdateLabelMana(int currentMana)
    {
        Text labelMana = GameObject.Find("LabelMana").GetComponent<Text>();

        if (labelMana)
        {
            labelMana.text = "Manas: " + $"{currentMana}";
        }
    }

    public void ShowLabelManaWarning(bool status)
    {
        Text labelManaWarning = GameObject.Find("LabelManaWarning").GetComponent<Text>();

        if (labelManaWarning)
        {
            labelManaWarning.text = status ? "Sem mana suficiente" : "";
        }
    }
}
