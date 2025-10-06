using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    //Array for level buttons
public Button[] buttons;

private void Awake()
{
    //Grabs highest unlocked level
    int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

    //Disable all buttons, then enable those for unlocked levels
    for (int i = 0; i < buttons.Length; i++)
    {
        buttons[i].interactable = false;
    }
    for (int i = 0; i < unlockedLevel; i++)
    {
        buttons[i].interactable = true;
    }
}

    //Load selected level
    public void OpenLevel(int levelID)
    {
        string levelName = "Level" + levelID;
        SceneManager.LoadScene(levelName);
    }
}
