using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    public Text finalScoreText;
    public Text highScoreText;

    void Start()
    {
        // Load scores from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Update text fields
        if (finalScoreText != null)
            finalScoreText.text = "Your Score: " + finalScore.ToString("#,0");

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString("#,0");
    }

    // Called when Restart button is clicked
    public void RestartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    // Optional Quit button
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
