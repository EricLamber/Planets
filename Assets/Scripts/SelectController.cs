using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : IController
{
    private Material selectionMaterial;
    //private Material highlightMaterial;
    private Material originalMaterial;
    //private Material selectoriginalMaterial;
    //private Transform highlight;
    //private Transform selection;
    private Transform selected;
    

    public void OnStart()
    {
        selectionMaterial = Game.DataRoot.Levels[0].m_SpawnData.Planet.selectionMaterial;
        //highlightMaterial = Game.DataRoot.Levels[0].m_SpawnData.Planet.highlightMaterial;
    }

    public void OnStop(){}

    public void OnUpdate()
    {
        /*if (highlight != null)
        {
            highlight.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
            highlight = null;
        }


        if (Physics.Raycast(ray, out hit))
        {
            highlight = hit.transform;

            if ((highlight.CompareTag("PlayerPlanet") || highlight.CompareTag("EmptyPlanet")) && highlight != selected )
            {
                if (highlight.GetComponentInChildren<MeshRenderer>().material != highlightMaterial)
                {
                    originalMaterial = highlight.GetComponentInChildren<MeshRenderer>().material;
                    highlight.GetComponentInChildren<MeshRenderer>().material = highlightMaterial;
                }
            }
            else
                highlight = null;
        }*/

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Game.Player.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;

                

                if (selection.CompareTag("PlayerPlanet") && selected == null)
                {
                    selected = selection;
                    originalMaterial = selection.GetComponentInChildren<MeshRenderer>().material;
                    selection.GetComponentInChildren<MeshRenderer>().material = selectionMaterial;
                }
                else if ((selection.CompareTag("EmptyPlanet") && selected != null)||
                    (selection.CompareTag("PlayerPlanet") && selected != selection))
                {
                    SpawnInvadors(selection.GetComponentInParent<PlanetView>().Planet);
                    selected.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
                    selected = null;
                }
                else if (selected != null && (selection == null || selection.CompareTag("Void")))
                {
                    selected.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
                    selected = null;
                }
                else
                    selection = null;
            }
        }
    }

    private void SpawnInvadors(PlanetBase target)
    {
        var planet = selected.GetComponentInParent<PlanetView>().Planet;
        int numinvadors = planet.Health / 2;

        for (int i = 0; i < numinvadors; i++)
        {
            InvadorView invadorView = Object.Instantiate(Game.DataRoot.Levels[0].m_SpawnData.Planet.invadorPrefab, selected.position, Quaternion.identity);
            InvadorBase invador = new InvadorBase(invadorView, planet, target);
            Game.Player.InvadorAdd(invador);
            planet.HealthFall(1);
        }
    }

}
