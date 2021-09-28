using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class GD3_GeneratePlanet : MonoBehaviour
{
    public PhotonView myPW;
    public GameObject prefabPlanet;

    public void SpawnPlanetAction(string name)
    {
        myPW.RPC("DoSpawnPlanet", RpcTarget.All, name);
    }

    [PunRPC]
    public void DoSpawnPlanet(string name)
    {
        var go = Instantiate(prefabPlanet, null);
        go.GetComponent<Planet>().GeneratePlanet();
        go.name = name;
    }
}
