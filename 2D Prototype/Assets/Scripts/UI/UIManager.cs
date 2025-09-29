using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Game over screen and sound
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    //Pause screen
    [Header ("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        //Screens are not active initially
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        //Pause menu toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

    //Show game over screen and sound
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Restart scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Return to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game
    public void Quit()
    {
        Application.Quit();
    }







    //Pause and resume game
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        //Time frozen when paused, unfrozen on resume
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }

    //Change volume of sound effects
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    //Change volume of music
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

}
