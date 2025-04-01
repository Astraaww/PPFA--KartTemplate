using KartGame.KartSystems;
using UnityEngine;
using System.Collections;

public class PlayerBoost : MonoBehaviour
{
    private KeyboardInput keyboardInput;
    public ArcadeKart kart;

    private float initialSpeed;
    private float boostedSpeed = 70f;

    private float boostLength = 1f;

    private void Awake()
    {
        keyboardInput = GetComponent<KeyboardInput>();
        initialSpeed = kart.baseStats.TopSpeed;
    }

    private void Update()
    {
        // Récupère la donnée de Boost
        if (keyboardInput.GenerateInput().Boost)
        {
            // Si Boost est activé, applique un boost à la vitesse
            StartCoroutine(BoostCoroutine());
        }

        Debug.Log("CurrentSpeed : " + kart.baseStats.TopSpeed);
    }

    IEnumerator BoostCoroutine()
    {
        // Par exemple, augmenter la vitesse de 50% pendant un certain temps
        kart.baseStats.TopSpeed = boostedSpeed;
        yield return new WaitForSeconds(boostLength);
        kart.baseStats.TopSpeed = initialSpeed;
    }

    
}

