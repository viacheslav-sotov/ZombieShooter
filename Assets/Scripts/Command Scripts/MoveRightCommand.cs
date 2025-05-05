//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : ICommand
{
    private Player player;
    public MoveRightCommand(Player p) => player = p;
    public void Execute() => player.SetVelocity(Vector2.right);
    public void Undo() => player.SetVelocity(Vector2.left);
}