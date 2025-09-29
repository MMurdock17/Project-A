using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    //Restart level and set time scale back to normal
    public void LoadCurrentScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
