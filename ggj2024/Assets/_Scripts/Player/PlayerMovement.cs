using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StepSounds
{
    public string Tag;
    public AudioClip[] StepClips;
}

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private StepSounds[] walkClips;
    [SerializeField] private float timeBetweenStepSounds;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    private SpriteRenderer _spriteRenderer;

    private Dictionary<string, AudioClip[]> soundsDictionary=new();
    private AudioClip[] currentStepSound;
    private AudioSource _source;
    private PlayerMeleeAttack meleeAttack;

    private Vector3 velocity;
    private float stepsTimer;
    private float hor;
    private float ver;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        meleeAttack = GetComponentInChildren<PlayerMeleeAttack>();
    }

    void Start()
    {
        foreach (var clip in walkClips)
        {
            soundsDictionary.Add(clip.Tag, clip.StepClips);
        }
        SetStepSounds("Grass");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Vector3 move = (new Vector2(hor, ver)).normalized * speed * Time.fixedDeltaTime;
        Vector3 targetSpeed = move * 50;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetSpeed, ref velocity, .1f);

        // rb.velocity = (new Vector2(hor, ver)).normalized * speed;

        //if (hor < 0)
        //    transform.rotation = Quaternion.Euler(new Vector3 (0, 180, 0));
        //else if(hor > 0)
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        _spriteRenderer.flipX = (hor < 0);

        if (hor != 0 || ver != 0)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);

        StepSounds();
    }

    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
    }

    private void StepSounds()
    {
        if (rb.velocity.magnitude > 2)
        {
            stepsTimer = stepsTimer > 0 ? stepsTimer - Time.fixedDeltaTime : 0;

            if (stepsTimer <= 0)
            {
                _source.clip = currentStepSound[Random.Range(0, currentStepSound.Length)];
                _source.Play();
                stepsTimer = timeBetweenStepSounds;
            }
        }
        else
        {
            _source.Stop();
        }
    }

    public void SetStepSounds(string soundsTag)
    {
        currentStepSound = soundsDictionary[soundsTag];
    }

    public void ShowAttack()
    {
        meleeAttack.ShowAttack();
    }
}
