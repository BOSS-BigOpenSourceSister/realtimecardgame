using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Core.Cards;
using Gameplay.Core.Actions;
using Gameplay.Core;
using  Gameplay.Core;

public class RandomTimeSpawner : MonoBehaviour
{
    public GameObject spawnObject;
 
     public float maxTime = 50;
     public float minTime = 10;

     private float time;
 
     //The time to spawn the object
     public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
         time = minTime;
        
    }
         //Sets the random time between minTime and maxTime
     void SetRandomTime(){
         spawnTime = Random.Range(minTime, maxTime);
         Debug.Log ("Next object spawn in " + spawnTime + " seconds.");
     }
    // Update is called once per frame
    void Update()
    {
                 //Counts up
         time += Time.deltaTime;
 
         //Check if its the right time to spawn the object
         if(time >= spawnTime){
             OnPlayerUsedCard(CardType.Warrior, Team.Visitor, 0);
             SetRandomTime();
             time = 0;
         }
    }
}
