using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public TypeOfFaith typeOfFaith;
    private Vector3 direction;
    private float speed;
    private int poolArrayIndex;
    public void Throw(Vector3 direction, float speed, int poolArrayIndex)
    {
        this.direction = direction;
        this.speed = speed;
        this.poolArrayIndex = poolArrayIndex;
        this.transform.LookAt(this.transform.position + direction);

        StartCoroutine(End());
    }

    private IEnumerator End()
    {
        yield return new WaitForSeconds(3);
        Player.Instance.throwableController.GiveObjectBack(this, poolArrayIndex);
    }

    private void FixedUpdate()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Believer believer;
        if ((believer = other.GetComponentInParent<Believer>()) != null)
        {
            if (believer.faith == typeOfFaith)
            {
                Debug.Log("bitch went to heaven.");
            }
            else
            {
                Debug.Log("bitch went to hell.");
            }
            Player.Instance.throwableController.GiveObjectBack(this, poolArrayIndex);
            StopAllCoroutines();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Scenery"))
        {
            Player.Instance.throwableController.GiveObjectBack(this, poolArrayIndex);
        }
    }
}
