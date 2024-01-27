using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    [SerializeField] private CountdownTimer _countdownTimer;
    [SerializeField] private int TimeToUnlock;

    [SerializeField] private Image icon;
    [SerializeField] private Image abilityCooldown;

    [SerializeField] private PlayerShoot playerShoot;

    [SerializeField] private float maxCD;
    private void Awake()
    {
        icon.enabled = false;
        abilityCooldown.enabled = false;
        playerShoot.enabled = false;


        maxCD = playerShoot.AttackCD;
        CountdownTimer.OnTimeElapsed += UnlockAbility;
    }
    private void Update()
    {
        abilityCooldown.fillAmount = 1f - (float)(playerShoot.AttackCDTimer / maxCD);
    }

    private void UnlockAbility(int timeElapsed)
    {
        if (TimeToUnlock==timeElapsed)
        {
            print($"Time to unlock {TimeToUnlock}, timeelapsed: {timeElapsed}");

            icon.enabled = true;
            abilityCooldown.enabled = true;
            playerShoot.enabled = true;
        }
    }
}
