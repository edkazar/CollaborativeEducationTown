using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject destination;

    public Material portalMaterial;
    public Camera portalCamera;
    public RenderTexture portalTexture;
    public Image fadeImage;

    public float fadeDuration = .8f;

    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isTeleporting)
        {
            StartCoroutine(TeleportPlayer());
        }
    }

    private IEnumerator TeleportPlayer()
    {
        isTeleporting = true;

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

        // Teleport player
        player.transform.position = destination.transform.position;

        // Fade back to normal
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = Color.Lerp(targetColor, originalColor, timer / fadeDuration);
            yield return null;
        }

        isTeleporting = false;
    }
}
