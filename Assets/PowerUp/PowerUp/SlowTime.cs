using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SlowTime : MonoBehaviour
{
    public float slowMotionFactor = 0.5f; // 0.5 means 50% speed (slow-motion)

    // How long the slow-motion effect will last
    public float duration = 5.0f; // 5 seconds

    // Called when the power-up is collected
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ActivateSlowMotion());
            // gameObject.SetActive(false);
        }
    }

    // Coroutine to handle the slow-motion effect
    private IEnumerator ActivateSlowMotion()
    {
        // Store the initial time scale
        float originalTimeScale = Time.timeScale;

        // Calculate the new time scale for slow motion
        Time.timeScale = slowMotionFactor;

        // Calculate the new fixed delta time to keep physics simulations stable
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        // Wait for the duration of the slow-motion effect
        yield return new WaitForSecondsRealtime(duration);

        // Restore the original time scale
        Time.timeScale = originalTimeScale;

        // Restore the original fixed delta time
        Time.fixedDeltaTime = 0.02f;
    }
}
