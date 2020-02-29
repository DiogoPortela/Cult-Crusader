using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class BelieverManager : SingletonBehaviour<BelieverManager>
{
    public int numberOfRepetitions;
    public int numberOfInitialMobsToSpawn;
    public Believer[] believerTemplates;
    private ObjectPool[] allObjectPools;

    private void Start()
    {
        allObjectPools = new ObjectPool[believerTemplates.Length];
        for (int i = 0; i < believerTemplates.Length; i++)
        {
            allObjectPools[i] = new ObjectPool(numberOfRepetitions, believerTemplates[i].gameObject);
        }
        for (int i = 0; i < allObjectPools.Length; i++)
        {
            for (int j = 0; j < numberOfInitialMobsToSpawn; j++)
            {

                Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50));
                Believer spawn = allObjectPools[i].GetObject(randomPos).GetComponent<Believer>();
                spawn.Init(i);
            }
        }
    }

    public void ReturnObject(Believer believer, int index)
    {
        allObjectPools[index].GiveObject(believer.gameObject);
    }
}
