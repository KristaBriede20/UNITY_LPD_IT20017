using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    public Button resumeButton;

    private bool isPaused = false;
    private bool cursorWasLocked = false;

    private void Start()
    {
        pauseScreen.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
public void ResumeGame()
    {
        TogglePause();  // Resume the game by toggling the pause state
    }
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;  // Set time scale to 0 to pause the game
            pauseScreen.SetActive(true);  // Show the pause screen GameObject
            Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
            Cursor.visible = true;  // Make the cursor visible
        }
        else
        {
            Time.timeScale = 1f;  // Set time scale back to 1 to resume the game
            pauseScreen.SetActive(false);  // Hide the pause screen GameObject
            Cursor.lockState = CursorLockMode.Locked;  // Lock the cursor to the center of the screen
            Cursor.visible = false;  // Hide the cursor
        }
    }

    
}