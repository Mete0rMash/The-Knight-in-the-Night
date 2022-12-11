using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanRoll { get; private set; }
    private bool isHolding;
    private bool rollInputStop;

    private float lastRollTime;

    private Vector2 rollDirection;
    private int rollDirectionInput;
    private Vector2 lastAfterImagePos;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        CanRoll = false;
        player.InputHandler.UseRollInput();

        isHolding = true;
        rollDirection = Vector2.right * Movement.FacingDirection;

        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.unscaledTime;

        player.RollDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        if (Movement.CurrentVelocity.y > 0)
        {
            Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.rollEndYMultiplier);
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
            player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));

            if (isHolding)
            {
                rollDirectionInput = player.InputHandler.RollDirectionInput;
                rollInputStop = player.InputHandler.RollInputStop;

                if (rollDirectionInput != 0)
                {
                    rollDirection.x = rollDirectionInput;
                    rollDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, rollDirection);
                player.RollDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if(rollInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    player.Anim.SetBool("roll", true);
                    isHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    Movement?.CheckIfShouldFlip(Mathf.RoundToInt(rollDirection.x));
                    player.RB.drag = playerData.drag;
                    Movement?.SetVelocity(playerData.rollVelocity, rollDirection);
                    player.RollDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {
                Movement?.SetVelocity(playerData.rollVelocity, rollDirection);
                CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.rollTime)
                {
                    player.Anim.SetBool("roll", false);
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastRollTime = Time.time;
                }
            }
        }
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if(Vector2.Distance(player.transform.position, lastAfterImagePos) >= playerData.distBetweenAfterImages)
        {
            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        //PlayerAfterImagePool.Instance.GetFromPool();
        lastAfterImagePos = player.transform.position;
    }

    public bool CheckIfCanRoll()
    {
        return CanRoll && Time.time >= lastRollTime + playerData.rollCooldown;
    }

    public void ResetCanRoll() => CanRoll = true;

}
