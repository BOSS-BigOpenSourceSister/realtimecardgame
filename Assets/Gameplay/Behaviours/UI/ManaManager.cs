using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public int mana = 0;
    public int manaMaxValue = 12;
    public float timeRemaining = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log(mana);
            }
        }
    }

    
}
