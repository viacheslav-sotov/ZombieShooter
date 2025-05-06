//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostDecorator : IPlayerMovement
{
    private IPlayerMovement baseMovement;
    private float boostMultiplier;
    private float boostDuration;
    private float timer;

    public SpeedBoostDecorator(IPlayerMovement baseMovement, float multiplier, float duration)
    {
        this.baseMovement = baseMovement;
        boostMultiplier = multiplier;
        boostDuration = duration;
        timer = duration;
    }

    public void Move(Player player, Vector2 input)
    {
        timer -= Time.deltaTime;

        if (timer > 0)
        {
            float originalSpeed = player.speed;
            player.speed = originalSpeed * boostMultiplier;
            baseMovement.Move(player, input);
            player.speed = originalSpeed; 
        }
        else
        {
            player.SetMovementStrategy(baseMovement);
            baseMovement.Move(player, input); 
        }
    }
}

