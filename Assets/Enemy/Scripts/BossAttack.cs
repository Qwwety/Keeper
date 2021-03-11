using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public static BossAttack Instance;

    private Rigidbody2D Rigidbody;
    private Animator animator;
    [Header("ForAttack")]
    public bool IsReadyToAttack = false;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRadius;
    [SerializeField] private LayerMask Enemies;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject DeadCutScene;
    [Header("Sound")]
    [SerializeField] private AudioClip[] AttacksSounds;
    [SerializeField] private AudioSource Sound;
    public bool CanReceiveImput;//
    public bool ImputRecived;//

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        IsReadyToAttack = Physics2D.OverlapCircle(AttackPoint.position, AttackRadius, Enemies);
        Attack();
    }

    private void Attack()
    {
        if (IsReadyToAttack)
        {
            if (CanReceiveImput)
            {
                ImputRecived = true;
                CanReceiveImput = false;
            }
            else
            {
                return;
            }
        }
    }


    public void SoundClassicAttack()
    {
        Sound.clip = AttacksSounds[0];
        Sound.Play();
    }
    public void SoundClassicAttack2()
    {
        Sound.clip = AttacksSounds[3];
        Sound.Play();
    }
    public void SoundAttackFromTop()
    {
        Sound.clip = AttacksSounds[1];
        Sound.Play();
    }
    public void SoundStabAttack()
    {
        Sound.clip = AttacksSounds[2];
        Sound.Play();
    }

    public void Dead()
    {
        EndScreen.SetActive(true);
        DeadCutScene.SetActive(true);
    }
    public void InputManager()
    {
        if (!CanReceiveImput)
        {
            CanReceiveImput = true;
        }
        else
        {
            CanReceiveImput = false;
        }
    }
    public void DoDamage(float Damage)
    {
        if (IsReadyToAttack)
        {
            HealthAndTakeDamage.Instance.TakeDamage(Damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(AttackPoint.position, AttackRadius);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            HealthAndTakeDamage.Instance.TakeDamage(10);
        }
    }
}
