using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Believer : MonoBehaviour
{
    public TypeOfFaith faith;
    public ParticleSystem badDeathParticleSystem;
    private NavMeshAgent navMeshAgent;
    private int index;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(GenerateDirection());
    }

    private IEnumerator GenerateDirection()
    {
        while (true)
        {
            Vector3 newWorldPosition = new Vector3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50));
            navMeshAgent.SetDestination(newWorldPosition);
            int random = UnityEngine.Random.Range(3, 10);
            yield return new WaitForSeconds(random);
        }
    }

    public void Die(bool wrongFaith)
    {
        if (wrongFaith)
        {
            badDeathParticleSystem.Play();
        }
        else
        {

        }

        BelieverManager.Instance.ReturnObject(this, index);
    }

    internal void Init(int index)
    {
        this.index = index;
    }
}
