using UnityEngine;

public class ObjectsMovements : MonoBehaviour
{
    public GameObject metro;
    public GameObject ptArrivé;
    public float speed = 5f;

    //private void OnTriggerEnter (Collider col)
    //{
    //    Movement();
    //}

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
            metro.transform.position = Vector3.MoveTowards(metro.transform.position, ptArrivé.transform.position, speed);
        
        while(metro.transform.position != ptArrivé.transform.position)
        {
            Debug.Log("Move");
        }
    }
}
