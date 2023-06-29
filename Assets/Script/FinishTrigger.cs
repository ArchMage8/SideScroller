using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            StartCoroutine(TransitionToNextScene());
        }
    }

    private IEnumerator TransitionToNextScene()
    {
        // Play the transition animation
        transitionAnimator.SetTrigger("Start");

        // Wait for the transition time
        yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        // Reset player's positional data to zero in PlayerPrefs
        PlayerPrefs.SetFloat("SavedPositionX", 0);
        PlayerPrefs.SetFloat("SavedPositionY", 0);
        PlayerPrefs.Save();

        // Load the next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}