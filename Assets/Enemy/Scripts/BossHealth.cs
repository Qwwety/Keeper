using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public static BossHealth Instance;

    private Animator animator;
    [Header("Health")]
    [SerializeField] private float CurrentHealth;
    [SerializeField] private float MaxHealth=1000;
    [SerializeField] private Slider HealthSlider;
    [Header("Stamina")]
    [SerializeField] private float CurrentStamina;
    [SerializeField] private float MaxStamina;
    [Header("DamageEffect")]
    [SerializeField] private GameObject BloodEffect;
    [Header("Dead")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject DeadCutScene;
    [SerializeField] private AudioClip[] SoundStartAndEnd;
    [SerializeField] private AudioSource Sound;
    void Start()
    {
        CurrentHealth = MaxHealth;
        HealthSlider.maxValue= MaxHealth;
        HealthSlider.value = CurrentHealth;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    public void TakeDamage(float Damage)
    {
        if (CurrentHealth<=0)
        {
            Player.SetActive(false);
            animator.SetTrigger("Dead");
           
        }
        CurrentHealth -= Damage;
        HealthSlider.value -= Damage;
        Instantiate(BloodEffect,transform.position, Quaternion.identity);
        //SpriteRenderer.color = CurrentColor;

    }

    public void TakeSwordInHandSound()
    {
        Sound.clip = SoundStartAndEnd[0];
        Sound.Play();
    }
    public void CutAtTheEnd()
    {
        Sound.clip = SoundStartAndEnd[3];
        Sound.Play();
    }
    public void StabAtTheEnd()
    {
        Sound.clip = SoundStartAndEnd[1];
        Sound.Play();
    }
    public void DeadBodyFall()
    {
        Sound.clip = SoundStartAndEnd[2];
        Sound.Play();
    }

}
