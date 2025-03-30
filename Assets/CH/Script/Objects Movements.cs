using UnityEngine;

public class ObjectsMovements : MonoBehaviour
{
    public GameObject metro;
    public GameObject ptArriv�;
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
            metro.transform.position = Vector3.MoveTowards(metro.transform.position, ptArriv�.transform.position, speed);
        
        while(metro.transform.position != ptArriv�.transform.position)
        {
            Debug.Log("Move");
        }
    }
}
