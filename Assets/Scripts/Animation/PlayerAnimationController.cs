using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator downerAnimator;
    [SerializeField] private Animator upperAnimator;

    private Animator animator;
    private bool isJumping = false;

    private readonly int IDLE_HASH = Animator.StringToHash("Idle");
    private readonly int WALK_HASH = Animator.StringToHash("Walk");
    private readonly int JUMP_HASH = Animator.StringToHash("Jump");
    private readonly int ATTACK_HASH = Animator.StringToHash("Attack");

  //void Awake()
  //{
  //    animator = GetComponent<Animator>();
  //}

    public void PlayerIdle()
    {

    }

    public void PlayerWalk(bool walking)
    {
        downerAnimator.SetBool("isWalking", walking);
        upperAnimator.SetBool("isWalking", walking);
    }

    public void SetJumping(bool jumping)
    {
        isJumping = jumping;


        downerAnimator.SetBool("isJumping", jumping);
        upperAnimator.SetBool("isJumping", jumping);
    }


    public void PlayerAttack()
    {
        if (isJumping)
        {

            downerAnimator.SetTrigger("JumpAttack");
        }
        else
        {
            upperAnimator.SetTrigger("Attack");
        }
    }


}
