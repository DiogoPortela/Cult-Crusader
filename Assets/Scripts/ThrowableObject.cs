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

        StartCoroutine(End());
    }

    private IEnumerator End(){
        yield return new WaitForSeconds(3);
        Player.Instance.throwableController.GiveObjectBack(this, poolArrayIndex);
    }

    private void FixedUpdate() {
        this.transform.position += direction * speed * Time.deltaTime;
    }
}
