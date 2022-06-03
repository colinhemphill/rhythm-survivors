using TMPro;
using UnityEngine;

public class PauseGame
{
    private TMP_Text text;
    private bool isPaused = false;

    public PauseGame(TMP_Text text)
    {
        this.text = text;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        text.enabled = true;
        isPaused = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
        text.enabled = false;
        isPaused = false;
    }
}
