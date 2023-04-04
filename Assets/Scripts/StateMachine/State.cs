using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnStart(BotController botController);

    public abstract void OnUpdate(BotController botController);

    public abstract void OnExit(BotController botController);
}