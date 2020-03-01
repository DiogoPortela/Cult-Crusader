using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : SingletonBehaviour<GameUI>
{
    public RectTransform escape;
    public GameObject scoreImage;
    public GameObject timeImage;
    public GameObject weaponImage;
    public GameObject EndScreen;
    public TMP_Text score;
    public TMP_Text time;
    public Image throwableImage;

    public TMP_Text endScore;


    private void Update()
    {
        int minutes = (int)(GameManager.Instance.currentTime / 60.0f);
        int seconds = (int)(GameManager.Instance.currentTime % 60);

        time.text = $"{minutes.ToString()}:{seconds.ToString("00")}";
    }

    public void End(){
        EndScreen.SetActive(true);
        endScore.text = ScoreManager.Instance.Score.ToString();
        scoreImage.SetActive(false);
        timeImage.SetActive(false);
        weaponImage.SetActive(false);

    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
