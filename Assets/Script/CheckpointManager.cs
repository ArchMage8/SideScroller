using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Vector3 respawnPoint;
    private bool hasInteractedWithCheckpoint = false;

    private void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform.position;
            hasInteractedWithCheckpoint = true;
            Debug.Log("Player respawn point updated: " + respawnPoint);
        }
    }

    public void RespawnPlayer()
    {
        if (hasInteractedWithCheckpoint)
        {
            transform.position = respawnPoint;
        }
        else
        {
            // No checkpoint interaction, respawn at initial position
            transform.position = respawnPoint; // Or any other default respawn position
        }
    }
}
