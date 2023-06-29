using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public float moveDistance = 1f;         // The distance the object moves up and down
    public float moveDuration = 2f;         // The duration of each movement
    private bool movingUp = false;          // Flag to track if the object is moving up or down

    private void Start()
    {
        // Start the coroutine when the script is enabled
        StartCoroutine(MoveUpDown());
    }

    private IEnumerator MoveUpDown()
    {
        while (true)  // Loop infinitely
        {
            // Calculate the target position based on the current movement direction
            Vector3 targetPosition = movingUp ? transform.position + Vector3.up * moveDistance
                                              : transform.position + Vector3.down * moveDistance;

            // Calculate the speed at which the object should move
            float speed = moveDistance / moveDuration;

            // Move the object towards the target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;  // Wait for the next frame
            }

            // Reverse the movement direction
            movingUp = !movingUp;

            // Wait for a specific amount of time before starting the next movement
            yield return new WaitForSeconds(moveDuration);
        }
    }
}
