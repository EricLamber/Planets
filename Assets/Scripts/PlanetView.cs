using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetView : MonoBehaviour
{
    private PlanetBase m_Planet;

    public PlanetBase Planet => m_Planet;

    public void AttachBase(PlanetBase planet) => m_Planet = planet;
}
