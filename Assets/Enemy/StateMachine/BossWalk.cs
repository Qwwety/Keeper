using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : StateMachineBehaviour
{
    private Transform Player;
    private Rigidbody2D Rigidbody;
    private LookAtPlayer LookAtPlayer;
    [SerializeField] private float speed;
    private int CurrentArrack;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
            Rigidbody = animator.GetComponent<Rigidbody2D>();
            LookAtPlayer = animator.GetComponent<LookAtPlayer>();
            BossAttack.Instance.CanReceiveImput = true;
            BossAttack.Instance.ImputRecived = false;
            CurrentArrack = Random.RandomRange(1, 4);
        }
        catch { }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookAtPlayer.LookForPlayer();
        Vector2 target = new Vector2(Player.position.x, Rigidbody.position.y);
        Vector2 PlayerPosition = Vector2.MoveTowards(Rigidbody.position, target, speed * Time.fixedDeltaTime);
        Rigidbody.MovePosition(PlayerPosition);

        if (BossAttack.Instance.ImputRecived)
        {
            if (CurrentArrack == 1)
            {
                animator.SetTrigger("Attack1");
                BossAttack.Instance.InputManager();
                BossAttack.Instance.ImputRecived = false;
            }
            else if (CurrentArrack == 2)
            {
                animator.SetTrigger("AttackFromTop");
                BossAttack.Instance.InputManager();
                BossAttack.Instance.ImputRecived = false;
            }
            else if (CurrentArrack == 3)
            {
                animator.SetTrigger("StabAttack");
                BossAttack.Instance.InputManager();
                BossAttack.Instance.ImputRecived = false;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
