using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Utils;

public class GameUI : SingletonBehaviour<GameUI>
{
    public TMP_Text score;
    public TMP_Text time;
    public Image throwableImage;

    private void Update() {
        int minutes = (int)(GameManager.Instance.currentTime / 60.0f);
        int seconds = (int)(GameManager.Instance.currentTime % 60);

        time.text = $"{minutes.ToString()}:{seconds.ToString("00")}";
    }
}
