using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/DataRoot", fileName = "DataRoot")]
public class DataRoot : ScriptableObject
{
    //public SceneData UIScene;
    public List<LevelData> Levels;
}
