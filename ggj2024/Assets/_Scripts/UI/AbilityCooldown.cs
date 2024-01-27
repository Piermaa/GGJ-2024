using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    [SerializeField] private UnlockNotification notif;
    [SerializeField] private CountdownTimer _countdownTimer;
    [SerializeField] private int TimeToUnlock;

    [SerializeField] private Image icon;
    [SerializeField] private Image abilityCooldown;

    [SerializeField] private PlayerShoot playerShoot;

    [SerializeField] private float maxCD;
    [SerializeField][TextArea] private string onUnlockText;
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
            notif.UnlockAbilityNotif(onUnlockText);

            icon.enabled = true;
            abilityCooldown.enabled = true;
            playerShoot.enabled = true;
        }
    }
}
