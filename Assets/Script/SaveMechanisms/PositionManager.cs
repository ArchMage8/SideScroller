using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionManager : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player object

    private const string PositionXKey = "SavedPositionX";
    private const string PositionYKey = "SavedPositionY";
    private const string LevelKey = "SavedLevel";

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player transform reference is missing! Attach the player object to the script.");
            return;
        }

        // Get the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        // Check if player position data exists in PlayerPrefs
        if (PlayerPrefs.HasKey(PositionXKey) && PlayerPrefs.HasKey(PositionYKey))
        {
            // Retrieve position data
            float savedPositionX = PlayerPrefs.GetFloat(PositionXKey);
            float savedPositionY = PlayerPrefs.GetFloat(PositionYKey);

            // Check if the position data is not equal to vector (0, 0)
            if (savedPositionX != 0 || savedPositionY != 0)
            {
                // Check if the current scene matches the saved scene
                int savedLevel = PlayerPrefs.GetInt(LevelKey);
                string savedSceneName = "Level" + savedLevel;

                if (currentSceneName == savedSceneName)
                {
                    // Set the player's position based on the saved position data
                    playerTransform.position = new Vector2(savedPositionX, savedPositionY);
                    Debug.Log("Player position set to: (" + savedPositionX + ", " + savedPositionY + ")");
                }
                else
                {
                    // Place the player at vector (0, 0) since the current scene is different from the saved scene
                    playerTransform.position = Vector2.zero;
                    Debug.Log("Player placed at vector (0, 0) due to scene change.");
                }
            }
            else
            {
                // Check if the level key is not equal to 1
                if (PlayerPrefs.GetInt(LevelKey) != 1)
                {
                    // Do not change the player's position
                    Debug.Log("Player position remains unchanged.");
                }
                else
                {
                    // No position data found
                    Debug.Log("Position data not found in PlayerPrefs.");
                }
            }
        }
        else
        {
            // No position data found
            Debug.Log("Position data not found in PlayerPrefs.");
        }
    }
}
