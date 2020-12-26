using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerController_FSM player)
    {
        player.SetExpression(player.idleSprite);
    }

    /// <summary>
    /// As soon as we call player.TransitionToState the next frame's update will go to that
    ///   new player state object..
    /// </summary>
    /// <param name="player"></param>
    public override void Update(PlayerController_FSM player)
    {
        if (Input.GetButtonDown("Jump"))
        {
            player.Rbody.AddForce(Vector3.up * player.jumpForce);
            player.TransitionToState(player.JumpingState);
        }
        if (Input.GetButtonDown("Duck"))
        {
            player.TransitionToState(player.DuckingState);
        }

        if (Input.GetButtonDown("SwapWeapon"))
        {
            var usingWeapon01 = player.weapon01.gameObject.activeInHierarchy;
            player.weapon01.gameObject.SetActive(usingWeapon01 == false);
            player.weapon02.gameObject.SetActive(usingWeapon01);
        }
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {
        
    }
}
