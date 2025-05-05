//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Commands
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            var command = commandHistory.Pop();
            command.Undo();
        }
    }
}
