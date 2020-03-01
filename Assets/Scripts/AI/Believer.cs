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
    private SpriteRenderer spriteRenderer;
    private new Rigidbody rigidbody;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(GenerateDirection());
    }

    private IEnumerator GenerateDirection()
    {
        while (true)
        {
            Vector3 newWorldPosition = new Vector3(UnityEngine.Random.Range(-100, 100), 0, UnityEngine.Random.Range(-100, 100));
            navMeshAgent.SetDestination(newWorldPosition);
            int random = UnityEngine.Random.Range(3, 10);

            float direction = newWorldPosition.x - this.transform.transform.position.x;
            if (direction > 0)
                spriteRenderer.flipX = false;
            else
                spriteRenderer.flipX = true;

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
