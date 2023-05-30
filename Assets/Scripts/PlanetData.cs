using UnityEngine;

[CreateAssetMenu(menuName = "Datas/PlanetData", fileName = "PlanetData")]
public class PlanetData : ScriptableObject
{
    [Header("Num variables")]
    [SerializeField] private Vector2Int m_PlanetHealthRange;

    [SerializeField] private int m_PlayerPlanetStartHealth;
    [SerializeField] private int m_PlayerPlanetMAXHealth;
    [SerializeField] private int m_PlanetHealthToGrow;

    [SerializeField] private float m_PlanetHealthGrowCD;

    [Header("Materials")]
    [SerializeField] private Material m_highlightMaterial;
    [SerializeField] private Material m_selectionMaterial;
    [SerializeField] private Material m_PlayerMaterial;
    [SerializeField] private Material m_EnemyMaterial;
    [SerializeField] private Material m_EmptyMaterial;

    [Header("Prefabs")]
    [SerializeField] private PlanetView m_ViewPrefab;
    [SerializeField] private InvadorView m_InvadorPrefab;

    public Vector2Int PlanetHealthRange => m_PlanetHealthRange;
    public int PlayerPlanetStartHealth => m_PlayerPlanetStartHealth;
    public int PlayerPlanetMAXHealth => m_PlayerPlanetMAXHealth;
    public int PlanetHealthToGrow => m_PlanetHealthToGrow;
    public float PlanetHealthGrowCD => m_PlanetHealthGrowCD;
    public PlanetView ViewPrefab => m_ViewPrefab;
    public Material selectionMaterial => m_selectionMaterial;
    public Material highlightMaterial => m_highlightMaterial;
    public Material PlayerMaterial => m_PlayerMaterial;
    public Material EnemyMaterial => m_EnemyMaterial;
    public Material EmptyMaterial => m_EmptyMaterial;
    public InvadorView invadorPrefab => m_InvadorPrefab;
}
