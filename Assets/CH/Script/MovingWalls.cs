using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
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
            wall1.transform.position = Vector3.MoveTowards(wall1.transform.position, ptArrivé.transform.position, speed);
            wall2.transform.position = Vector3.MoveTowards(wall2.transform.position, ptArrivé.transform.position, speed);
        }
    }
}
