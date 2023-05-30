using System;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private List<IController> m_Controllers;
    private bool m_IsRunning = false;

    void Update()
    {
        if (!m_IsRunning)
            return;

        UpdateControllers();
    }

    public void StartRunning()
    {
        Game.Player.cam = Camera.main;
        CreateAllControllers();
        OnStartControllers();
        m_IsRunning = true;

    }

    public void StopRunning()
    {
        OnStopControllers();
        m_IsRunning = false;
    }

    private void CreateAllControllers()
    {
        m_Controllers = new List<IController>
        {
            new SpawnController(Game.DataRoot.Levels[0].m_SpawnData),
            new SelectController(),
            new PlanetGrowingController(),
            new InvasionController(),
            new WinController()
        };
    }

    private void OnStartControllers()
    {
        foreach (IController controller in m_Controllers)
        {
            try
            {
                controller.OnStart();
            }
            catch (Exception e)
            {

                Debug.LogError(e);
            }
        }
    }

    private void UpdateControllers()
    {
        foreach (IController controller in m_Controllers)
        {
            if (!m_IsRunning)
                return;
            try
            {
                controller.OnUpdate();
            }
            catch (Exception e)
            {

                Debug.LogError(e);
            }
        }
    }

    private void OnStopControllers()
    {
        foreach (IController controller in m_Controllers)
        {
            try
            {
                controller.OnStop();
            }
            catch (Exception e)
            {

                Debug.LogError(e);
            }
        }
    }
}