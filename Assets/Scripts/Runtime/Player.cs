using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player
{
    #region Common

    public Camera cam = null;

    public void CheckForWin()
    {
        if (m_PlayerPlanets.Count == m_Planets.Count)
        {
            GameWon();
        }
    }

    private async void GameWon()
    {
        Game.StopPlayer();
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        await Task.Delay(5000);
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Planets

    private List<PlanetBase> m_Planets = new List<PlanetBase>();
    public IReadOnlyList<PlanetBase> Planets => m_Planets;
    

    public void PlanetSpawned(PlanetBase planet)
    {
        m_Planets.Add(planet);
    }

    public void PlanetDied(PlanetBase planet)
    {
        m_Planets.Remove(planet);
    }
    
    private List<PlanetBase> m_PlayerPlanets = new List<PlanetBase>();
    public IReadOnlyList<PlanetBase> PlayerPlanets => m_PlayerPlanets;

    public void PlayerPlanetAdd(PlanetBase planet)
    {
        m_PlayerPlanets.Add(planet);
    }

    public void PlayerPlanetRemove(PlanetBase planet)
    {
        m_PlayerPlanets.Remove(planet);
    }

    #endregion

    #region Invador

    private List<InvadorBase> m_Invadors = new List<InvadorBase>();
    public IReadOnlyList<InvadorBase> Invadors => m_Invadors;

    public void InvadorAdd(InvadorBase Invador)
    {
        m_Invadors.Add(Invador);
    }

    public void InvadorRemove(InvadorBase Invador)
    {
        m_Invadors.Remove(Invador);
    }

    #endregion
}
