using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GamePause && !Controller.GameIsOver)
            {
                Resume();
            }
            else if (!Controller.GameIsOver)
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
        GCom.ResumeGame();
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        GamePause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        GCom.PauseGame();
    }
}
