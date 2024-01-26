using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseCharacter
{
    public bool StartCountDown;

    public bool MushroomPickUp;
    public bool SamusPickUp;
    public bool StarPickUp;
    public bool PackmanPickUp;

    [SerializeField] private float durationEffectTimer;

    private float countDown;
    private PlayerMovement playerMov;


    // Start is called before the first frame update
    void Start()
    {
        playerMov = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartCountDown)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown < 0.1f)
        {
            countDown = durationEffectTimer;
            StartCountDown = false;
            BackToNormal();
        }
    }

    public void ActivePickUp()
    {
        if (MushroomPickUp)
        {
            playerMov.transform.localScale *= 5;
            playerMov.speed = 2;
        }

        if (SamusPickUp)
        {
            //Sacar UI del casco
        }

        if (StarPickUp)
        {
            playerMov.speed = 20;
        }

        if (PackmanPickUp)
        {
            // Volver el sprite a la normalidad
            // Hacer que los enemigos se vean normal
        }
    }

    private void BackToNormal()
    {
        if(MushroomPickUp)
        {
            playerMov.transform.localScale = new Vector3(1, 1, 1);
            playerMov.speed = 5;
        }
            
        if(SamusPickUp)
        {
            //Sacar UI del casco
        }

        if(StarPickUp)
        {
            playerMov.speed = 5;
        }

        if(PackmanPickUp)
        {
            // Volver el sprite a la normalidad
            // Hacer que los enemigos se vean normal
        }

    }

    private void MushroomActive()
    {

    }

    private void SamusActive()
    {

    }

    private void StarActive()
    {

    }
    private void PackmanActive()
    {

    }
}
