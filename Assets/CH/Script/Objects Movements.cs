using UnityEngine;
using System.Collections;

public class ObjectsMovements : MonoBehaviour
{
    public GameObject metro;
    public GameObject ptArrivé;
    public float speed = 5f;

    private bool isTriggered = false;

    [Header("Sfx")]
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip trainHornSfx;
    public AudioClip trainPassesSfx;

    private void OnTriggerEnter(Collider col)
    {
        isTriggered = true;

        source1.clip = trainHornSfx;
        source1.Play();

        source2.clip = trainPassesSfx;
        source2.Play();
    }

    void Update()
    {
        if (isTriggered)
        {
            metro.transform.position = Vector3.MoveTowards(metro.transform.position, ptArrivé.transform.position, speed);
        }
    }
}
