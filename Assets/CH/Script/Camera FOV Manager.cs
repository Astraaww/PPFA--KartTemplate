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
        cam.fieldOfView = mainFov;  // Définir le FOV initial
    }

    public static void AugmentFov()
    {
        if (!isTransitioning)  // Vérifier qu'il n'y a pas déjà une transition
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

    // Coroutine statique pour gérer le changement progressif du FOV
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

        // Assurez-vous que la caméra atteint exactement la valeur cible à la fin
        cam.fieldOfView = targetFov;
        isTransitioning = false;  // Réinitialiser l'état de transition
    }
}
