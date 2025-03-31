using UnityEngine;

public class ObjectsMovements : MonoBehaviour
{
    public GameObject metro;
    public GameObject ptArrivé;
    public float speed = 5f;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider col)
    {
        isTriggered = true;
    }

    void Update()
    {
        if (isTriggered)
        {
            metro.transform.position = Vector3.MoveTowards(metro.transform.position, ptArrivé.transform.position, speed);
        }
    }
}
