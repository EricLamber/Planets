using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGrowingController : IController
{
    private PlanetData m_PlanetData;
    private float m_LastTick;

    public void OnStart()
    {
        m_PlanetData = Game.DataRoot.Levels[0].m_SpawnData.Planet;
    }

    public void OnStop(){}

    public void OnUpdate()
    {
        float passdTime = Time.time - m_LastTick;
        if (!(passdTime < m_PlanetData.PlanetHealthGrowCD))
        {
            foreach (var planet in Game.Player.PlayerPlanets)
            {
                if (planet.Health < m_PlanetData.PlayerPlanetMAXHealth)
                    planet.HealthGrow(m_PlanetData.PlanetHealthToGrow);
            }
            m_LastTick = Time.time;
        }
    }
}
