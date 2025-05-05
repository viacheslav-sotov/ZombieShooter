//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : ICommand
{
    private Player player;
    public MoveDownCommand(Player p) => player = p;
    public void Execute() => player.SetVelocity(Vector2.down);
    public void Undo() => player.SetVelocity(Vector2.up);
}
