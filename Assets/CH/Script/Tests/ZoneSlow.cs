using KartGame.KartSystems;
using UnityEngine;

public class ZoneSlow : MonoBehaviour
{
    public ArcadeKart kart;

    private float slowedSpeed = 1f;

    private float initialSpeed;

    private void Awake()
    {
        initialSpeed = kart.baseStats.TopSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        kart.baseStats.TopSpeed = slowedSpeed;
        Debug.Log("speed : " + kart.baseStats.TopSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        kart.baseStats.TopSpeed = initialSpeed;
        Debug.Log(" speed :" + kart.baseStats.TopSpeed);
    }

}
