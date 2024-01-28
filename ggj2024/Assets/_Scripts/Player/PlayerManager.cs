using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseCharacter
{
    public bool StartCountDown;

    public bool MushroomPickUp;
    public bool SamusPickUp;
    public bool StarPickUp;
    public bool PacmanPickUp;

    public bool playerCantAttack;

    [SerializeField] private float durationStarEffect;
    [SerializeField] private float durationSamusEffect;
    [SerializeField] private float durationPacmanEffect;
    [SerializeField] private float durationMushroomEffect;
    [SerializeField] private float regenSpeed = 2;
    private EnemySpawner spawnerRef;

    private float countDown;
    private PlayerMovement playerMov;
    private TrailRenderer trail;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        spawnerRef = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        playerMov = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();  
        trail.widthMultiplier = 0.0f;
        playerCantAttack = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        _currentHealth = _currentHealth<100 ? _currentHealth + Time.deltaTime*regenSpeed : 100;
        if (StartCountDown)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown < 0.1f)
        {
            countDown = 0;
            BackToNormal();
        }
    }

    public void ActivePickUp()
    {
        if (MushroomPickUp)
        {
            countDown = durationMushroomEffect;
            transform.localScale *= 5;
            playerMov.speed = 2;
        }

        if (SamusPickUp)
        {

            //Sacar UI del casco
        }

        if (StarPickUp)
        {
            countDown = durationStarEffect;
            playerMov.speed = 20;
            trail.widthMultiplier = .2f;
        }

        if (PacmanPickUp)
        {
            playerCantAttack = true;
            spawnerRef.SetPacmanMode();
            countDown = durationPacmanEffect;
            anim.SetBool("PacmanTime", true);
        }
    }

    private void BackToNormal()
    {
        StartCountDown = false;
        if (MushroomPickUp)
        {
            transform.localScale = new Vector3(1, 1, 1);
            playerMov.speed = 5;
            MushroomPickUp = false;
        }
            
        if(SamusPickUp)
        {
            //Sacar UI del casco
        }

        if(StarPickUp)
        {
            playerMov.speed = 5;
            StarPickUp = false;
            trail.widthMultiplier = 0.0f;
        }

        if(PacmanPickUp)
        {
            playerCantAttack = false;
            spawnerRef.FinishPacManMode();
            anim.SetBool("PacmanTime", false);
        }

    }
    public override void Death()
    {
        SceneManagement.Instance.LoadScene(2);
    }
}
