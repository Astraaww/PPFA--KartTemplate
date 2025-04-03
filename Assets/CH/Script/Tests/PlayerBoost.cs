using KartGame.KartSystems;
using UnityEngine;
using System.Collections;

public class PlayerBoost : MonoBehaviour
{
    [Header("float")]
    private float initialSpeed;
    private float boostForce = 50f;
    private float boostDuration = 1.5f;
    private float boostCd = 3f;

    private bool isBoosting = false;
    private Vector3 originalVelocity;

    [Header("References")]
    private KeyboardInput keyboardInput;
    public ArcadeKart kart;
    private Rigidbody rb;
    //public Camera Camera;


    private void Awake()
    {
        keyboardInput = GetComponent<KeyboardInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Récupère la donnée de Boost
        if (keyboardInput.GenerateInput().Boost && !isBoosting)
        {
            originalVelocity = rb.linearVelocity;
            initialSpeed = kart.baseStats.TopSpeed;

            StartCoroutine(BoostCoroutine());
        }

        //Debug.Log("current Speed :" + kart.baseStats.TopSpeed);
        //Debug.Log("Velocity : " + rb.linearVelocity);
    }

    IEnumerator BoostCoroutine()
    {
        isBoosting = true;
        Boosting();
        yield return new WaitForSeconds(boostDuration);

        StartCoroutine(BoostCd());

        ResetStats();
        isBoosting = false;
    }

    IEnumerator BoostCd()
    {
        if (isBoosting)
        {
            yield return new WaitForSeconds(boostCd);
        }
    }

    private void Boosting()
    {
        rb.AddForce(transform.forward * boostForce, ForceMode.VelocityChange);
        kart.baseStats.TopSpeed = initialSpeed;
        CameraFOVManager.AugmentFov();
    }

    private void ResetStats()
    {
        rb.linearVelocity = originalVelocity;
        CameraFOVManager.ResetFov();
    }

}
