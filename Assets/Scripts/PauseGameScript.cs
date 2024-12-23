using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false; 

    void Start()
    {
        pauseMenu.SetActive(false); 
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // Method to pause the game
    private void PauseGame()
    {
        Time.timeScale = 0f; 
        pauseMenu.SetActive(true); 
        isPaused = true; 
    }

    // Method to resume the game
    private void ResumeGame()
    {
        Time.timeScale = 1f; 
        pauseMenu.SetActive(false);
        isPaused = false; 
    }
}
