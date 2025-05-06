//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerMovement : IPlayerMovement
{
    public virtual void Move(Player player, Vector2 input)
    {
        player.SetVelocity(input);
    }
}

