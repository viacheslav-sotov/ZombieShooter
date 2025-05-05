//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : ICommand
{
    private Player player;

    public MoveUpCommand(Player p) => player = p;

    public void Execute() => player.SetVelocity(Vector2.up);
    public void Undo() => player.SetVelocity(Vector2.down); 
}