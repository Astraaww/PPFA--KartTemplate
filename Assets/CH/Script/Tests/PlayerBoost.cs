using KartGame.KartSystems;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBoost : MonoBehaviour
{
    [Header("Métriques")]
    private float initialSpeed;
    private float boostForce = 30f;
    private float boostDuration = 1.5f;
    
    private Vector3 originalVelocity;

    [Header("References")]
    private KeyboardInput keyboardInput;
    public ArcadeKart kart;
    private Rigidbody rb;

    [Header("UI")]
    [SerializeField] private Image imageCooldown;

    private bool isCooldown = false;
    public float cooldownTime = 20f;
    private float cooldownTimer = 0f;

    private void Awake()
    {
        keyboardInput = GetComponent<KeyboardInput>();
        rb = GetComponent<Rigidbody>();

        imageCooldown.fillAmount = 0;
    }

    private void Update()
    {
        if (keyboardInput.GenerateInput().Boost && !isCooldown) //Si j'active le boost et qu'il est pas en CD : j'active mon boost
        {
            originalVelocity = rb.linearVelocity; //stock la vélocité d'avant le boost
            initialSpeed = kart.baseStats.TopSpeed; //stock la TopSpeed d'avant le boost

            StartCoroutine(BoostCoroutine()); //Active le boost
        }
        else
        {
            //jouer un son qui dit que je peux pas lancer + shake l'ui ou un truc dans le genre
        }

        if(isCooldown) 
        {
            ApplyCooldown();
        }
    }

    IEnumerator BoostCoroutine()
    {
        isCooldown = true; //Je suis entrain de booster - va automatiquement lancer ApplyCooldown
        Boosting(); //Méthode qui gère la puisance du boost
        yield return new WaitForSeconds(boostDuration); //j'attend le temps que le boost soit finit
    }

    private void Boosting() 
    {
        rb.AddForce(transform.forward * boostForce, ForceMode.VelocityChange); //j'ajoute une force à mon véhicule
        CameraFOVManager.AugmentFov(); //j'applique le changement de Fov

        //kart.baseStats.TopSpeed = initialSpeed; //je set ma top speed à la speed inital ????
    }

    private void ResetStats() //Permet de remettre les métriques inital
    {
        rb.linearVelocity = originalVelocity;
        CameraFOVManager.ResetFov();
    }

    private void ApplyCooldown() //si le CD est inférieur à 0, pas en CD. Sinon, il est en CD et update l'UI --> doit être fait dans une update.
    {
        cooldownTimer = Time.deltaTime; //Update selon le framerate

        if (cooldownTimer < 0f) //si mon timer est écoulé
        {
            ResetStats();
            imageCooldown.fillAmount = 0; //Met à jour l'UI
            
            //Joue un son pour dire que mon spell est up
            
            isCooldown = false; //dis que je suis plus en Cd
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownTime; //Sinon : met à jour l'UI
        }
    }
}
