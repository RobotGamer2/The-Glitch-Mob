using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player) : base(player) { }


    public override void Enter()
    {
        base.Enter();

        anim.SetBool("isAttackingIdle", true);
        
    }

    public override void AttackAnimationFinished()
    {
        if (Mathf.Abs(MoveInput.x) > .1f)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttackingIdle", true);
    }


    public override void Exit()
    {
        base.Exit();

        anim.SetBool("isAttacking", false);
    }
}
