using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private DataRoot m_DataRoot;
    [SerializeField] private List<Button> m_MenuButtons = new();

    private void Awake()
    {
        m_MenuButtons[0].onClick.AddListener(CubeChoise);
    }

    private void CubeChoise()
    {
        Game.SetDataRoot(m_DataRoot);
        Game.StartLevel(m_DataRoot.Levels[0]);
    }
}
