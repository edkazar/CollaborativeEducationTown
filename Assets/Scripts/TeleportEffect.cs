using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportEffect : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    public float teleportDelay = 2.0f;
    public Transform teleportDestination;
    public Text countdownText;
    public AudioClip teleportSound;
    public AudioSource audioSource;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TeleportPlayer();
        }
    }
    
    public void TeleportPlayer()
    {
        StartCoroutine(TeleportEffectCoroutine());
    }

    private IEnumerator TeleportEffectCoroutine()
    {
        // Show countdown message
        const int countdownDuration = 5;
        for (int i = countdownDuration; i >= 1; i--)
        {
            countdownText.text = string.Format("Teleporting back to the teacher in {0}...", i);
            yield return new WaitForSeconds(1f);
        }
        countdownText.text = string.Empty; // Clear the countdown message

        // Fade to black
        fadeImage.gameObject.SetActive(true);
        Color originalColor = fadeImage.color;
        Color targetColor = new Color(0f, 0f, 0f, 1f);
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(originalColor, targetColor, timer / fadeDuration);
            yield return null;
        }

        // Wait for teleport delay
        yield return new WaitForSeconds(teleportDelay);

        // Teleport the player
        transform.position = teleportDestination.position;

        // Play teleport sound
        audioSource.PlayOneShot(teleportSound);

        // Fade back to normal
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(targetColor, originalColor, timer / fadeDuration);
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }
}
