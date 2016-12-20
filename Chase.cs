using UnityEngine;
using System.Collections;

public class Chase : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.SetColor(1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.FollowPlayer();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.ResumePatrol();
    }
}
