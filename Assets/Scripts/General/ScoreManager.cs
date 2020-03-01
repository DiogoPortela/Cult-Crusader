using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            GameUI.Instance.score.text = value.ToString();
        }
    }

    public void Reset()
    {
        Score = 0;
    }
}
