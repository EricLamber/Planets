using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public static class Game
{
    private static Player s_Player;
    private static DataRoot s_DataRoot;
    private static LevelData s_CurrentLevel;

    private static Runner s_Runner;

    public static Player Player => s_Player;
    public static DataRoot DataRoot => s_DataRoot;
    public static LevelData CurrentLevel => s_CurrentLevel;

    public static void SetDataRoot(DataRoot dataRoot)
    {
        s_DataRoot = dataRoot;
    }

    public static void StartLevel(LevelData levelData)
    {
        s_CurrentLevel = levelData;
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.completed += StartPlayer;
    }

    private static void StartPlayer(AsyncOperation operation)
    {
        if (!operation.isDone)
            throw new Exception("Can't load scene");

        s_Player = new Player();
        s_Runner = Object.FindObjectOfType<Runner>();
        s_Runner.StartRunning();

        //SceneManager.LoadScene(DataRoot.UIScene.name, LoadSceneMode.Additive);
    }
    public static void StopPlayer()
    {
        s_Runner.StopRunning();
    }
}
