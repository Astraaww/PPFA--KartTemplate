using UnityEngine;
using System.Collections;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;

    private void Awake()
    {
        // Assurer qu'une seule instance de CoroutineManager existe
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Méthode statique pour démarrer des coroutines
    public static void StartCustomCoroutine(System.Collections.IEnumerator coroutine)
    {
        if (instance != null)
        {
            instance.StartCoroutine(coroutine);
        }
        else
        {
            Debug.LogError("CoroutineManager instance not found. Make sure it's in the scene.");
        }
    }
}
