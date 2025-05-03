using KartGame.KartSystems;
using UnityEngine;

public class ZoneSlow : MonoBehaviour
{
    public ArcadeKart kart;

    [SerializeField]public float slowedSpeed = 1f;

    private float initialSpeed;
    private float initialReverseSpeed;

    //[Header("fx")]
    //public GameObject waterVfx;

    private void Awake()
    {
        //kart = GetComponent<ArcadeKart>();
        initialSpeed = kart.baseStats.TopSpeed;
        initialReverseSpeed = kart.baseStats.ReverseSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(kart.baseStats.TopSpeed);

        kart.baseStats.TopSpeed = slowedSpeed;
        kart.baseStats.ReverseSpeed = slowedSpeed;


        CameraFOVManager.ReduceFov();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(waterVfx, kart.transform.position, Quaternion.identity);

        //Debug.Log("in");
    }

    private void OnTriggerExit(Collider other)
    {
        kart.baseStats.TopSpeed = initialSpeed;
        kart.baseStats.ReverseSpeed = initialReverseSpeed;

        CameraFOVManager.ResetFov();
    }

}
