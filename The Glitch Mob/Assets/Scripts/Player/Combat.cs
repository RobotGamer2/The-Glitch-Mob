using UnityEngine;

public class Combat : MonoBehaviour
{

    public Player player;


    public void AttackAnimationFinished()
    {
        player.AttackAnimationFinished();
    }
}
