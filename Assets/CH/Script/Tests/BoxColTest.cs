using UnityEngine;

public class BoxColTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
    }
}
