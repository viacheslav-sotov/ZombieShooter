//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void OnHealthChanged(int newHealth);
}