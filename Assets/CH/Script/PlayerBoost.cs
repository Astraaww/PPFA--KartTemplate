using KartGame.KartSystems;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class PlayerBoost : MonoBehaviour
{
    [Header("Métriques")]
    private float initialSpeed;
    private float boostForce = 20f;
    private float boostDuration = 1.5f;
    
    private Vector3 originalVelocity;

    [Header("References")]
    private KeyboardInput keyboardInput;
    public ArcadeKart kart;
    private Rigidbody rb;

    [Header("UI")]
    [SerializeField] private Image imageCooldown;

    private bool isCooldown = false;
    private float cooldownDuration = 20f; //la durée du CD
    private float cooldownTimer = 0f;

    [Header("Sfx")]
    public AudioSource source;
    public AudioClip click;

    private void Awake()
    {
        keyboardInput = GetComponent<KeyboardInput>();
        rb = GetComponent<Rigidbody>();

    }

    private void Start()
    {
        imageCooldown.fillAmount = 1f;
    }

    private void Update()
    {

        if (keyboardInput.GenerateInput().Boost && !isCooldown) //Si j'active le boost et qu'il est pas en CD : j'active mon boost
        {
            originalVelocity = rb.linearVelocity; //stock la vélocité d'avant le boost
            initialSpeed = kart.baseStats.TopSpeed; //stock la TopSpeed d'avant le boost

            StartCoroutine(BoostCoroutine()); //Active le boost
            imageCooldown.fillAmount = 0f;
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
        isCooldown = true; 
        Boosting(); 
        yield return new WaitForSeconds(boostDuration);
        ResetStats();
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

    private void ApplyCooldown() 
    {
        
        cooldownTimer += Time.deltaTime;


        if (cooldownTimer >= cooldownDuration) 
        {
            cooldownTimer = 0f;
            //ResetStats();
            //imageCooldown.fillAmount = 1; //Met à jour l'UI

            //Joue un son pour dire que mon spell est up

            isCooldown = false; //plus en Cd
            source.clip = click;
            source.Play();

        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownDuration;
        }
    }
}
