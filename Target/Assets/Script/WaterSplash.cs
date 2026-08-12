using UnityEngine;
using System.Collections;

public class WaterSplash : MonoBehaviour
{
    public Transform waterSurface;

    public float splashScale = 1.5f;
    public float splashDuration = 0.5f;

    private Vector3 originalScale;

    void Start()
    {
        if (waterSurface == null)
            waterSurface = transform;

        originalScale = waterSurface.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        StopAllCoroutines();
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        float time = 0f;

        // Expand
        while (time < splashDuration / 2f)
        {
            time += Time.deltaTime;

            float t = time / (splashDuration / 2f);

            waterSurface.localScale = Vector3.Lerp(
                originalScale,
                originalScale * splashScale,
                t
            );

            yield return null;
        }

        // Return
        time = 0f;

        while (time < splashDuration / 2f)
        {
            time += Time.deltaTime;

            float t = time / (splashDuration / 2f);

            waterSurface.localScale = Vector3.Lerp(
                originalScale * splashScale,
                originalScale,
                t
            );

            yield return null;
        }

        waterSurface.localScale = originalScale;
    }
}