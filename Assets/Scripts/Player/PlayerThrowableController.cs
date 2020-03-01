using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Utils.Audio;

public class PlayerThrowableController : MonoBehaviour
{
    public float throwableSpeed = 10.0f;
    public int numberOfObjectsToWarmUp = 5;
    public AudioSource throwSound;
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
            throwSound.Play();
            var currentThrowableObject = poolsOfThrowableObjects[selectedThrowableObjectIndex].GetObject(this.transform.position);
            var currentThrowable = currentThrowableObject.GetComponent<ThrowableObject>();
            currentThrowable.Throw(arrowController.pointingArrowRef.transform.forward, throwableSpeed, selectedThrowableObjectIndex);
        }
        if (Input.GetKeyDown(Settings.Instance.weapon1))
            selectedThrowableObjectIndex = 0;
        else if (Input.GetKeyDown(Settings.Instance.weapon2))
            selectedThrowableObjectIndex = 1;
        else if (Input.GetKeyDown(Settings.Instance.weapon3))
            selectedThrowableObjectIndex = 2;
        else if (Input.GetKeyDown(Settings.Instance.weapon4))
            selectedThrowableObjectIndex = 3;
        else if (Input.GetKeyDown(Settings.Instance.weapon5))
            selectedThrowableObjectIndex = 4;
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel != 0)
            IncrementThrowableIndex((int)wheel);

        GameUI.Instance.throwableImage.sprite = throawbleObjectsTemplate[selectedThrowableObjectIndex].spriteObject;
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
        AudioManager.Instance.Play("WeaponSwitch");
        int index = selectedThrowableObjectIndex + incrementValue;
        if (index > 0)
            selectedThrowableObjectIndex = index % throawbleObjectsTemplate.Length;
        else
            selectedThrowableObjectIndex = (throawbleObjectsTemplate.Length + index) % throawbleObjectsTemplate.Length;

    }
}
