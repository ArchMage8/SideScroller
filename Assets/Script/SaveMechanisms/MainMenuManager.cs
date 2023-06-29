using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private const string LevelKey = "SavedLevel";
    private const string PositionXKey = "SavedPositionX";
    private const string PositionYKey = "SavedPositionY";

    public Animator transition;
    public float transitionTime = 1f;

    public void NewGame()
    {
        // Set the level to 1 (first level) and save it
        PlayerPrefs.SetInt(LevelKey, 1);

        // Set position data to (0, 0) and save it
        PlayerPrefs.SetFloat(PositionXKey, 0);
        PlayerPrefs.SetFloat(PositionYKey, 0);

        PlayerPrefs.Save();

        // Load the first level scene with animation
        StartCoroutine(LoadAnimation("Level1"));
    }

    public void ContinueGame()
    {
        // Check if the saved level exists
        if (PlayerPrefs.HasKey(LevelKey))
        {
            // Load the saved level scene with animation
            int savedLevel = PlayerPrefs.GetInt(LevelKey);
            StartCoroutine(LoadAnimation("Level" + savedLevel));
        }
        else
        {
            // If no saved level exists, start a new game
            NewGame();
        }
    }

    IEnumerator LoadAnimation(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
