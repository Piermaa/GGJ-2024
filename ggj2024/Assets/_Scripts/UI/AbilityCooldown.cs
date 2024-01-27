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

    private float maxCD;
    private void Awake()
    {
        maxCD = playerShoot.AttackCD;
        CountdownTimer.OnTimeElapsed += UnlockAbility;
    }
    private void Update()
    {
        abilityCooldown.fillAmount = playerShoot.AttackCDTimer / maxCD;
    }

    private void UnlockAbility(int timeElapsed)
    {
        if (TimeToUnlock==timeElapsed)
        {
            icon.enabled = true;
            abilityCooldown.enabled = true;
        }
    }
}
