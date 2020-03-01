using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Utils.Audio;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float timeLimit = 120.0f;
    public float currentTime = 0;
    public bool isRunning;

    private void Start()
    {
        AudioManager.Instance.Play("Start");
        AudioManager.Instance.Play("Music");
        currentTime = timeLimit;
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                Debug.Log("Time's up!");
                Player.Instance.throwableController.enabled = false;
                Player.Instance.movementController.enabled = false;
                Player.Instance.arrowController.enabled = false;
                AudioManager.Instance.Play("End");
                isRunning = false;
                //StartCoroutine(End());
                GameUI.Instance.End();
                
            }

            if(Input.GetKeyDown(KeyCode.Escape)){
                GameUI.Instance.escape.gameObject.SetActive(true); 
            }
        }
    }

    private IEnumerator End(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
