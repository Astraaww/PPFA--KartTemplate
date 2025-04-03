using UnityEngine;
using System.Collections;

public class CameraFOVManager : MonoBehaviour
{
    private static Camera cam;

    public static float mainFov = 90f;
    public static float slowedFov = 80f;
    public static float boostedFov = 110f;
    public static float transitionSpeed = 60f;

    private static bool isTransitioning = false;
    private static float targetFov;
    private static float currentFov;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = mainFov;  // D�finir le FOV initial
    }

    public static void AugmentFov()
    {
        if (!isTransitioning)  // V�rifier qu'il n'y a pas d�j� une transition
        {
            isTransitioning = true;
            targetFov = boostedFov;
            currentFov = cam.fieldOfView;
            CoroutineManager.StartCustomCoroutine(HandleFovTransition());
        }
    }

    public static void ResetFov()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            targetFov = mainFov;
            currentFov = cam.fieldOfView;
            CoroutineManager.StartCustomCoroutine(HandleFovTransition());
        }
    }

    public static void ReduceFov()
    {
        if (!isTransitioning)
        {
            isTransitioning = true;
            targetFov = slowedFov;
            currentFov = cam.fieldOfView;
            CoroutineManager.StartCustomCoroutine(HandleFovTransition());
        }
    }

    // Coroutine statique pour g�rer le changement progressif du FOV
    private static System.Collections.IEnumerator HandleFovTransition()
    {
        float transitionDuration = Mathf.Abs(targetFov - currentFov) / transitionSpeed;

        float timeElapsed = 0f;

        while (timeElapsed < transitionDuration)
        {
            cam.fieldOfView = Mathf.Lerp(currentFov, targetFov, timeElapsed / transitionDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Assurez-vous que la cam�ra atteint exactement la valeur cible � la fin
        cam.fieldOfView = targetFov;
        isTransitioning = false;  // R�initialiser l'�tat de transition
    }
}
