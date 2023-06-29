using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public CheckpointManager checkpointManager;
    public Animator transitionAnimator;
    public float transitionTime = 1f; // Transition time in seconds
    public float respawnDelay = 2f; // Delay in seconds before respawn

    private bool isRespawning = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") && !isRespawning)
        {
            // Pause the game
            Time.timeScale = 0f;

            // Perform death logic here (e.g., play death animation)
            PlayDeathAnimation();

            // Start respawn coroutine
            StartCoroutine(RespawnCoroutine());
        }
    }

    private void PlayDeathAnimation()
    {
        // Play the "CrossFade_Start" animation
        transitionAnimator.Play("CrossFade_Start");
    }

    private IEnumerator RespawnCoroutine()
    {
        // Set respawning flag to prevent multiple respawns
        isRespawning = true;

        // Delay the respawn
        yield return new WaitForSecondsRealtime(respawnDelay);

        // Resume the game
        Time.timeScale = 1f;

        // Respawn the player using the checkpoint manager
        checkpointManager.RespawnPlayer();

        // Play the "CrossFade_End" animation after the player respawns
        transitionAnimator.Play("CrossFade_End");

        // Wait for the transition animation to complete
        yield return new WaitForSecondsRealtime(transitionTime);

        // Reset respawning flag
        isRespawning = false;
    }
}
