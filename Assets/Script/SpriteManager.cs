using System.Collections;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject[] sprites;
    public float interval = 1f;
    public float fadeDuration = 0.5f;

    private int currentIndex = 0;
    private SpriteRenderer[] spriteRenderers;

    private void Start()
    {
        spriteRenderers = new SpriteRenderer[sprites.Length];

        // Get the sprite renderer components from the sprite game objects
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderers[i] = sprites[i].GetComponent<SpriteRenderer>();
        }

        // Start the coroutine to enable sprites at the specified interval
        StartCoroutine(EnableSpritesCoroutine());
    }

    private IEnumerator EnableSpritesCoroutine()
    {
        while (true)
        {
            // Enable the current sprite
            EnableSprite(currentIndex);
            StartCoroutine(FadeInSprite(spriteRenderers[currentIndex]));

            // Wait for the interval duration
            yield return new WaitForSeconds(interval);

            // Disable the current sprite
            StartCoroutine(FadeOutSprite(spriteRenderers[currentIndex]));
            DisableSprite(currentIndex);

            // Move to the next sprite index
            currentIndex = (currentIndex + 1) % sprites.Length;
        }
    }

    private IEnumerator FadeInSprite(SpriteRenderer spriteRenderer)
    {
        float timer = 0f;
        Color targetColor = spriteRenderer.color;

        // Fade in the sprite
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            spriteRenderer.color = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);
            yield return null;
        }

        // Ensure the sprite is fully visible
        spriteRenderer.color = targetColor;
    }

    private IEnumerator FadeOutSprite(SpriteRenderer spriteRenderer)
    {
        float timer = 0f;
        Color targetColor = spriteRenderer.color;

        // Fade out the sprite
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            spriteRenderer.color = new Color(targetColor.r, targetColor.g, targetColor.b, alpha);
            yield return null;
        }

        // Ensure the sprite is fully transparent
        spriteRenderer.color = new Color(targetColor.r, targetColor.g, targetColor.b, 0f);
    }

    private void EnableSprite(int index)
    {
        sprites[index].SetActive(true);
    }

    private void DisableSprite(int index)
    {
        sprites[index].SetActive(false);
    }
}
