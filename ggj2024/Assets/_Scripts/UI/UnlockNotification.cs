using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;
    public void UnlockAbilityNotif(string text)
    {
        tmpro.text = text;
        StartCoroutine(UnlockTime());

    }

    private IEnumerator UnlockTime()
    {
        yield return new WaitForSeconds(5);
        tmpro.text = string.Empty;
    }
}
