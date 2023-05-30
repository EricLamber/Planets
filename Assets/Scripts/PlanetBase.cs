using Random = UnityEngine.Random;
using TMPro;
using UnityEngine;

public class PlanetBase
{
    private PlanetView m_View;
    private PlanetData m_Data;
    private int m_Health;
    private TextMeshProUGUI m_HealthText;
    private bool m_IsOcupiedByPlayer;
    private bool m_IsOcupiedByEnemy;

    public PlanetView View => m_View;
    public PlanetData Data => m_Data;
    public int Health => m_Health;
    public TextMeshProUGUI HealthText => m_HealthText;
    public bool IsOcupiedByPlayer => m_IsOcupiedByPlayer;
    public bool IsOcupiedByEnemy => m_IsOcupiedByEnemy;

    public PlanetBase(PlanetData data, PlanetView view, bool IsPlayerPlanet)
    {
        m_Data = data;

        AttachView(view);

        if(!IsPlayerPlanet)
        {
            m_Health = Random.Range(data.PlanetHealthRange.x, data.PlanetHealthRange.y);
            m_IsOcupiedByEnemy = false;
            m_IsOcupiedByPlayer = false;
            m_View.transform.GetChild(0).tag = "EmptyPlanet";
        }
        else
        {
            m_Health = data.PlayerPlanetStartHealth;
            m_IsOcupiedByEnemy = false;
            m_IsOcupiedByPlayer = true;
            m_View.transform.GetChild(0).tag = "PlayerPlanet";
        }

        m_HealthText = m_View.GetComponentInChildren<TextMeshProUGUI>();
        m_HealthText.text = m_Health.ToString();
    }

    public void AttachView(PlanetView view)
    {
        m_View = view;
        m_View.AttachBase(this);
    }

    public void HealthGrow(int hp)
    {
        m_Health += hp;
        m_HealthText.text = m_Health.ToString();
    }
    
    public void HealthFall(int hp)
    {
        m_Health -= hp;
        m_HealthText.text = m_Health.ToString();
    }

    public void PlanetChange(PlanetBase invadorplanet)
    {
        if (m_Health != 0)
            return;

        if(!IsOcupiedByEnemy && !IsOcupiedByPlayer && invadorplanet.View.transform.GetChild(0).tag == "PlayerPlanet")
        {
            m_View.transform.GetChild(0).tag = "PlayerPlanet";
            m_View.GetComponentInChildren<MeshRenderer>().material = Game.DataRoot.Levels[0].m_SpawnData.Planet.PlayerMaterial;
            m_IsOcupiedByPlayer = true;
            Game.Player.PlayerPlanetAdd(this);
        }
    }

}
