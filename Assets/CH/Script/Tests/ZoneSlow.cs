using KartGame.KartSystems;
using UnityEngine;

public class ZoneSlow : MonoBehaviour
{
    public ArcadeKart kart;

    private float slowedSpeed = 1f;

    private float initialSpeed;
    private float initialReverseSpeed;

    [Header("fx")]
    public GameObject waterVfx;

    private void Awake()
    {
        initialSpeed = kart.baseStats.TopSpeed;
        initialReverseSpeed = kart.baseStats.ReverseSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        kart.baseStats.TopSpeed = slowedSpeed;
        kart.baseStats.ReverseSpeed = slowedSpeed;


        CameraFOVManager.ReduceFov();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(waterVfx, kart.transform.position, Quaternion.identity);
        
    }

    private void OnTriggerExit(Collider other)
    {
        kart.baseStats.TopSpeed = initialSpeed;
        kart.baseStats.ReverseSpeed = initialReverseSpeed;

        CameraFOVManager.ResetFov();
    }

}
