using KartGame.KartSystems;
using UnityEngine;

public class ZoneSlow : MonoBehaviour
{
    public ArcadeKart kart;

    private float slowedSpeed = 1f;

    private float initialSpeed;
    private float initialReverseSpeed;

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

    private void OnTriggerExit(Collider other)
    {
        kart.baseStats.TopSpeed = initialSpeed;
        kart.baseStats.ReverseSpeed = initialReverseSpeed;
        CameraFOVManager.ResetFov();
    }

}
