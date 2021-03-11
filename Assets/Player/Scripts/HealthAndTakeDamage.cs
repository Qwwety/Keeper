using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndTakeDamage : MonoBehaviour
{
    public static HealthAndTakeDamage Instance;


    public bool Isinvincibility;
    private Animator Animator;
    private GameObject BossGameObject;
    [Header("Health")]
    [SerializeField] private float MaxHealth;
    [SerializeField] private float CurrentHealth;
    [SerializeField] private Slider HealthSlider;
    [Header("KnockBack")]
    [SerializeField] private Vector2 ForceAngle;
    [SerializeField] private float KnockBackSpeed;
    [SerializeField] Rigidbody2D BossRB;
    private Rigidbody2D PlayerRB;
    [Header("ParryEffect")]
    [SerializeField] private AudioSource ParrySounds;
    [SerializeField] private Animator EffectAnimator;
    [Header("Dead")]
    public  bool CanDie=true;
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject DeadCutScene;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerRB = GetComponent<Rigidbody2D>();
        BossGameObject = GameObject.FindGameObjectWithTag("Boss");
        CurrentHealth = MaxHealth;
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = CurrentHealth;
    }

    public void TakeDamage(float Damage)
    {
        if (Isinvincibility==false)
        {
            CurrentHealth -= Damage;
            HealthSlider.value -= Damage;
            Animator.SetTrigger("TakeDamage");
            //StartCoroutine(AddDamageForce());
        }
        else if(AttackAndParry.Instance.IsParrying == true)
        {
            BossGameObject.GetComponent<Animator>().SetTrigger("Parried");
            EffectAnimator.SetTrigger("ParryEffect");
            ParrySounds.Play();
        }

        if (CurrentHealth<=0 && Isinvincibility == false)
        {
            Animator.SetTrigger("Dead");
        }
    }

    public void KnockBackByHit()
    {
        PlayerRB.velocity = new Vector2(-BossRB.transform.localScale.x*KnockBackSpeed * ForceAngle.x, PlayerRB.velocity.y*ForceAngle.y);
    }
    
    public void Dead()
    {
         EndScreen.SetActive(true);
        DeadCutScene.SetActive(true);
    }
}

