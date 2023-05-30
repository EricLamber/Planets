using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InvadorBase
{
    private InvadorView m_View;

    private PlanetBase m_StartPlanet;
    private PlanetBase m_TargetPlanet;

    private NavMeshAgent m_Agent;

    private bool m_IsDied;

    public InvadorView View => m_View;

    public bool IsDied => m_IsDied;

    public InvadorBase(InvadorView view, PlanetBase startplanet, PlanetBase tergetplanet)
    {
        AttachView(view);
        m_TargetPlanet = tergetplanet;
        m_StartPlanet = startplanet;
        m_Agent = view.transform.GetComponent<NavMeshAgent>();
    }

    public void AttachView(InvadorView view)
    {
        m_View = view;
        m_View.AttachBase(this);
    }

    public void Invasion()
    {
        var target = m_TargetPlanet.View.transform.position;

        m_Agent.SetDestination(target);

        if(Vector3.Distance(m_View.transform.position, target) <= 0.7)
        {
            if (m_TargetPlanet.View.transform.GetChild(0).tag != m_StartPlanet.View.transform.GetChild(0).tag)
                m_TargetPlanet.HealthFall(1);
            else if (m_TargetPlanet.View.transform.GetChild(0).CompareTag(m_StartPlanet.View.transform.GetChild(0).tag))
                m_TargetPlanet.HealthGrow(1);

            m_TargetPlanet.PlanetChange(m_StartPlanet);
            m_IsDied = true;
        }
    }

    public void Die()
    {
        View.Die();
    }
}
