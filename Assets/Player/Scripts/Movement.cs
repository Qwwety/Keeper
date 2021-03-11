using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement Instance;

    [SerializeField] private Transform BossTransform;
    [Header("ForMovement")]
    [SerializeField] private float MovementSpeed;
    [Header("ForJump")]
    [SerializeField] private LayerMask TypeOfGround;
    [SerializeField] private Transform FeetPosition;
    [SerializeField] private float JumpForce;
    [SerializeField] private float RadiusOfCheckingGround;
    [SerializeField] private bool IsGrounded;
    [Header("ForDodge")]
    [SerializeField] private float DodgeSpeed;
    [SerializeField] private AudioSource DodgeSounds;
    public bool CanDodge=true;
    public bool IsDodging=false;
    private float MoveDirection;
    private bool LookingRight = true;
    private Rigidbody2D PlayerRB;
    private Animator Animator;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        //HealthBar.SetMaxHealth(MaxHealth);
        //ManaBar.SetMaxMana(MaxMana);
    }
    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(FeetPosition.position, RadiusOfCheckingGround, TypeOfGround);
        Animator.SetBool("IsStayOnGround", IsGrounded);
        if (AttackAndParry.Instance.IsParrying == false && IsDodging == false)
        {
            Speed();
            Jump();
            Dodge();
        }
        Rotate();
    }

    private void Jump()
    {
        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            Animator.SetTrigger("GoToFall");
            PlayerRB.AddForce(new Vector2(PlayerRB.velocity.x, JumpForce));
        }
    }

    private void Dodge()
    {
        if (Input.GetButtonDown("Dodge") && MoveDirection != 0)
        {
            float CurrentDirection = MoveDirection;
            if (CanDodge == true)
            {
                CanDodge = false;
                IsDodging = true;
                PlayerRB.velocity = new Vector2(CurrentDirection * DodgeSpeed, PlayerRB.velocity.y);
                HealthAndTakeDamage.Instance.Isinvincibility = true;
                DodgeSounds.Play();
            }
        }
    }
    public void EndDodge()
    {
        CanDodge = true;
        IsDodging = false;
        HealthAndTakeDamage.Instance.Isinvincibility = false;
    }

    //private IEnumerator EndDodge()
    //{
    //    yield return new WaitForSeconds(DodgingTime);
    //    Animator.SetTrigger("StopDodge");
    //    BossGameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    //    CanDodge = true;
    //    IsDodging = false;
    //    HealthAndTakeDamage.Instance.invincibility = true;
    //}

    //public void CheckDodge()
    //{
    //    if (Vector2.Distance(this.transform.position, BossTransform.position) > 2f)
    //    {
    //        BossGameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    //    }
    //    else
    //    {
    //        BossGameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    //    }
    //}
    private void Speed()
    {
        MoveDirection = Input.GetAxisRaw("Horizontal");
        PlayerRB.velocity = new Vector2(MoveDirection * MovementSpeed, PlayerRB.velocity.y);
        Animator.SetFloat("RunSpeed", Mathf.Abs(MoveDirection));
    }
    private void Rotate()
    {
        if (!LookingRight && MoveDirection > 0)
        {
            Flip();
        }
        else if (LookingRight && MoveDirection < 0)
        {
            Flip();
        }
    }
    private void Flip()
    {
        LookingRight = !LookingRight;
        Vector3 Transformer = transform.localScale;
        Transformer.x *= -1;
        transform.localScale = Transformer;
    }
    private void OnDrawGizmosSelected()
    {
        if (FeetPosition == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(FeetPosition.position, RadiusOfCheckingGround);
    }
}
