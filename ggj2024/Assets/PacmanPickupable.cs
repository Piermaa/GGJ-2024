using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanPickupable : OnPlayerTriggerEnter
{
    private ParticleSystem pacmanParticles;

    private void Start()
    {
        pacmanParticles = GameObject.Find("PacmanEffect").GetComponent<ParticleSystem>();
    }

    protected override void Trigger(GameObject playerObject)
    {
        PlayerManager pj = playerObject.GetComponent<PlayerManager>();

        pacmanParticles.Play();

        pj.StartCountDown = true;
        pj.PacmanPickUp = true;

        pj.ActivePickUp();

        Destroy(gameObject);
    }
}
