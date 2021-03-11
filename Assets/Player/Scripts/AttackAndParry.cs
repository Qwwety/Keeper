using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAndParry : MonoBehaviour
{
    public static AttackAndParry Instance;
    [SerializeField] private BossHealth BossHealth;

    private Animator Animator;
    [Header("ForParry")]
    [SerializeField] private AudioSource ParrySounds;
    public bool IsParrying;
    [Header("ForAttack")]
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRange;
    [SerializeField] private LayerMask EnenemyLayers;
    [SerializeField] private float Damage;
    [SerializeField] private AudioSource AttackSounds;
    private bool CanDoDamage;
    public bool CanReceiveImput;//
    public bool ImputRecived;//

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        BossHealth = BossHealth.GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CanDoDamage = Physics2D.OverlapCircle(AttackPoint.position, AttackRange, EnenemyLayers);
        if (Movement.Instance.IsDodging == false && IsParrying==false)
        {
            Attack();
            Parry();
        }
    }


    private void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            if (CanReceiveImput)
            {
                ImputRecived = true;
                CanReceiveImput = false;
                DoDamage();
               AttackSounds.Play();
            }
            else
            {
                return;
            }
            Debug.Log("Attack");
        }
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



    private void Parry()
    {
        if (Input.GetButtonDown("Parry"))
        {
            Animator.SetTrigger("Parry");
            HealthAndTakeDamage.Instance.Isinvincibility = true;
            IsParrying = true;
            ParrySounds.Play();
        }
    }
    public void StopParring()
    {
        IsParrying = false;
        StopInvincibility();
    }
    public void StopInvincibility()
    {
        HealthAndTakeDamage.Instance.Isinvincibility = false;
    }
    private void DoDamage()
    {
        if (CanDoDamage == true)
        {
            BossHealth.TakeDamage(Damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
