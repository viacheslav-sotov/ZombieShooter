//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : ICommand
{
    private Player player;
    public MoveLeftCommand(Player p) => player = p;
    public void Execute() => player.SetVelocity(Vector2.left);
    public void Undo() => player.SetVelocity(Vector2.right);
}