using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlayerThrowableController : MonoBehaviour
{
    public float throwableSpeed = 10.0f;
    public int numberOfObjectsToWarmUp = 5;
    public ThrowableObject[] throawbleObjectsTemplate;
    private ObjectPool[] poolsOfThrowableObjects;
    private int selectedThrowableObjectIndex;
    private PlayerArrowController arrowController;

    private void Awake()
    {
        poolsOfThrowableObjects = new ObjectPool[throawbleObjectsTemplate.Length];
        for (int i = 0; i < throawbleObjectsTemplate.Length; i++)
        {
            poolsOfThrowableObjects[i] = new ObjectPool(numberOfObjectsToWarmUp, throawbleObjectsTemplate[i].gameObject);
        }
        selectedThrowableObjectIndex = 0;
        arrowController = GetComponent<PlayerArrowController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Settings.Instance.playerThrow))
        {
            var currentThrowableObject = poolsOfThrowableObjects[selectedThrowableObjectIndex].GetObject(this.transform.position);
            var currentThrowable = currentThrowableObject.GetComponent<ThrowableObject>();
            currentThrowable.Throw(arrowController.pointingArrowRef.transform.forward, throwableSpeed, selectedThrowableObjectIndex);
        }
    }
    public void GiveObjectBack(ThrowableObject obj, int index)
    {
        poolsOfThrowableObjects[index].GiveObject(obj.gameObject);
    }
    public void SetThrowableIndex(int index)
    {
        if (index > 0 && index < throawbleObjectsTemplate.Length)
            selectedThrowableObjectIndex = index;
    }
    public void IncrementThrowableIndex(int incrementValue)
    {
        int index = selectedThrowableObjectIndex + incrementValue;
        selectedThrowableObjectIndex = index % throawbleObjectsTemplate.Length;
    }
}
