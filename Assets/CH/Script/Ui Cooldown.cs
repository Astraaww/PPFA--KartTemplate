using UnityEngine;
using UnityEngine.UI;


public class UiCooldown : MonoBehaviour
{
    [SerializeField] private Image imageCooldown;

    private bool isCooldown;
    private float cooldownTime = 10f;
    private float cooldownTimer = 0f;

    private void Start()
    {
        imageCooldown.fillAmount = 0;
    }

    private void Update() //appel apply CD, si boost est en CD
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    private void ApplyCooldown() //si le CD est inférieur à 0, pas en CD. Sinon, il est en CD et update l'UI
    {
        cooldownTimer = Time.deltaTime; //Update selon le framerate

        if(cooldownTimer < 0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0;
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer /cooldownTime;
        }
    }
    private void UseBoost() 
    {
        if (isCooldown)
        {

        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }
}
