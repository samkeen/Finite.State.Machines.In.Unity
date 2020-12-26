using UnityEngine;

public class PlayerSpinningState : PlayerBaseState
{

    private float rotation = 0f;
    public override void EnterState(PlayerController_FSM player)
    {
         player.SetExpression(player.spinningSprite);
    }

    public override void Update(PlayerController_FSM player)
    {
        float amountToRotate = 900 * Time.deltaTime;
        rotation += amountToRotate;
        if (rotation < 360)
        {
            player.transform.Rotate(Vector3.up, amountToRotate);
        }
        else
        {
            player.transform.rotation = Quaternion.identity;
            rotation = 0;
            player.TransitionToState(player.JumpingState);
        }
        
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
        player.transform.rotation = Quaternion.identity;
        player.TransitionToState(player.IdleState);
    }
}
