using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;
    private Text txtCom; // reference to game object text component

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        // Check to see if PlayerPrefs_HighScore already exist; read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        // ASsign the highscore value
        PlayerPrefs.SetInt("Highscore", SCORE);
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT! != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#.0");
            }
        }
    }

    static public void TRY_SET_HIGHSCORE(int scoreToTry)
    {
        if (scoreToTry <= _SCORE)
        {
            return;
        }
        _SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in playerPref")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);

        }
    }
}
