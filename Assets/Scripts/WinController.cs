using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : IController
{
    public void OnStart(){}

    public void OnStop(){}

    public void OnUpdate()
    {
        Game.Player.CheckForWin();
    }
}
