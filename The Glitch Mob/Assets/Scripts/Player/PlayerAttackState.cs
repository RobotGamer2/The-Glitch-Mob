using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player) : base(player) { }


    public override void Enter()
    {
        base.Enter();

        if (Mathf.Abs(MoveInput.x) > .1f)
            anim.SetBool("isAttacking", true);
        else
            anim.SetBool("isAttackIdle", true);

    }

    public override void AttackAnimationFinished()
    {
        if (Mathf.Abs(MoveInput.x) > .1f)
            player.ChangeState(player.moveState);
        else
            player.ChangeState(player.idleState);
    }


    public override void Exit()
    {
        base.Exit();

        anim.SetBool("isAttacking", false);
        anim.SetBool("isAttackIdle", false);
    }
}
