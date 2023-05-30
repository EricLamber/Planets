using UnityEngine;
using UnityEngine.AI;

public class SpawnController : IController
{
    private SpawnData m_SpawnData;

    public SpawnController(SpawnData spawnData) => m_SpawnData = spawnData;

    public void OnStart()
    {
        var plane = GameObject.Find("Plane");
        plane.SetActive(false);
        Spawn();
        plane.SetActive(true);
        var surface = plane.GetComponent<NavMeshSurface>();
        surface.BuildNavMesh();
    }

    public void OnStop() { }

    public void OnUpdate() { }

    private void Spawn()
    {
        for (int loop = 0, s = 0; loop < m_SpawnData.NumberOfPlanetsOnField; loop++)
        {
            Vector3 spawnPoint = Game.Player.cam.ScreenToWorldPoint(new Vector3(Random.Range(100, Screen.width - 100),
                Random.Range(50, Screen.height - 50), Game.Player.cam.farClipPlane * 0.5f));

            if (!Physics.CheckSphere(spawnPoint, m_SpawnData.SpawnRadius))
            {
                PlanetView planetView = Object.Instantiate(m_SpawnData.Planet.ViewPrefab, spawnPoint, Quaternion.identity);

                planetView.transform.LookAt(Game.Player.cam.transform.position);

                if (loop == 0)
                    planetView.GetComponentInChildren<MeshRenderer>().material = m_SpawnData.Planet.PlayerMaterial;

                Canvas canvas = planetView.GetComponentInChildren<Canvas>();

                canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.forward, Vector3.forward);

                PlanetBase planet = new PlanetBase(m_SpawnData.Planet, planetView, loop == 0);

                if (loop == 0)
                    Game.Player.PlayerPlanetAdd(planet);

                Game.Player.PlanetSpawned(planet);

                s = 0;
            }
            else if (s < 10)
            {
                loop--;
                s++;
            }
        }
    }
}
