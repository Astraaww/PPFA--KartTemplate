using UnityEngine;
using System.Collections;
using UnityEngine.Splines;

public class ObjectsMovements : MonoBehaviour
{

    public SplineAnimate splineAnimate;

    [Header("Sfx")]
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip trainHornSfx;
    public AudioClip trainPassesSfx;

    private void OnTriggerEnter(Collider col)
    {
        splineAnimate.Play();

        source1.clip = trainHornSfx;
        source1.Play();

        source2.clip = trainPassesSfx;
        source2.Play();
    }

}
