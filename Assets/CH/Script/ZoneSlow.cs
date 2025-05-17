using KartGame.KartSystems;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static Unity.VisualScripting.Member;

public class ZoneSlow : MonoBehaviour
{
    public ArcadeKart kart;

    [SerializeField]public float slowedSpeed = 20f;

    private float initialSpeed;
    private float initialReverseSpeed;
    private float initialAcceleration;

    public AudioSource source;
    public AudioClip waterSfx;

    private void Awake()
    {
        //kart = GetComponent<ArcadeKart>();
        initialSpeed = kart.baseStats.TopSpeed;
        initialReverseSpeed = kart.baseStats.ReverseSpeed;
        initialAcceleration = kart.baseStats.Acceleration;
    }

    private void OnTriggerStay(Collider other)
    {

        kart.baseStats.TopSpeed = slowedSpeed;
        kart.baseStats.ReverseSpeed = slowedSpeed;
        kart.baseStats.Acceleration = 4f;
        kart.baseStats.ReverseAcceleration = 4f;

        //other.attachedRigidbody.linearVelocity.magnitude = slowedSpeed;

        CameraFOVManager.ReduceFov();
    }

    private void OnTriggerEnter(Collider other)
    {

        source.clip = waterSfx;
        source.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        kart.baseStats.TopSpeed = initialSpeed;
        kart.baseStats.ReverseSpeed = initialReverseSpeed;
        kart.baseStats.Acceleration = initialAcceleration;

        CameraFOVManager.ResetFov();

        source.Stop();
    }

}
