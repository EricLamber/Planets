using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasionController : IController
{
    private List<InvadorBase> m_DiedInvaidor = new List<InvadorBase>();

    public void OnStart(){}

    public void OnStop(){}

    public void OnUpdate()
    {
        foreach (var invaidor in Game.Player.Invadors)
        {
            invaidor.Invasion();
            if (invaidor.IsDied)
            {
                m_DiedInvaidor.Add(invaidor);
                invaidor.Die();
            }
        }

        foreach(var diedinvador in m_DiedInvaidor)
        {
            Game.Player.InvadorRemove(diedinvador);
        }
        m_DiedInvaidor.Clear();
    }
}
