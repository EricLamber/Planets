using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/m_SpawnData", fileName = "m_SpawnData")]
public class SpawnData : ScriptableObject
{
    public int NumberOfPlanetsOnField;
    public PlanetData Planet;
    public float SpawnRadius;
}