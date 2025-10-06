using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	public void PlayGame()
	{
		//Load Level 1
		SceneManager.LoadSceneAsync(1);
	}

	//Quit game
	public void QuitGame()
	{
		Application.Quit();
	}

}
