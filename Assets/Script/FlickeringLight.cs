using System.Collections;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Start the flickering coroutine
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Enable or disable the sprite renderer randomly
            spriteRenderer.enabled = Random.value > 0.5f;

            // Wait for a random duration
            yield return new WaitForSeconds(Random.Range(0.05f, 1f));
        }
    }
}
