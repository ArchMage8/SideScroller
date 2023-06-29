using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionSaver : MonoBehaviour
{
    private const string LevelKey = "SavedLevel";
    private const string PositionXKey = "SavedPositionX";
    private const string PositionYKey = "SavedPositionY";

    private void OnDisable()
    {
        // Save the current level
        int currentLevel = GetCurrentLevel();
        PlayerPrefs.SetInt(LevelKey, currentLevel);
        Debug.Log("Saved Level: " + currentLevel);

        // Save the player position
        Vector2 currentPosition = transform.position;
        PlayerPrefs.SetFloat(PositionXKey, currentPosition.x);
        PlayerPrefs.SetFloat(PositionYKey, currentPosition.y);
        Debug.Log("Saved Position: (" + currentPosition.x + ", " + currentPosition.y + ")");

        // Save the PlayerPrefs
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs saved.");
    }

    private int GetCurrentLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        // Assuming your level scene names follow the format "Level1", "Level2", etc.
        int levelNumber = int.Parse(sceneName.Substring(5));
        return levelNumber;
    }
}
