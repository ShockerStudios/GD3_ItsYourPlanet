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

    public ShapeSettings[] shapeSettingsTemplate;
    public ColourSettings[] colorSettingsTemplate;
    public GameObject[] extrasList;

    [Space(10)]
    public GD3Gradient[] gradients;

    private ShapeSettings shapeForNewPlanet;
    private ColourSettings colorForNewPlanet;
    private GameObject extraToSpawn;

    public void StartNewPlanet(int planetPreset)
    {
        switch (planetPreset)
        {
            case 0:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[0]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[0]);
                break;
            case 1:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[1]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[1]);
                break;
            case 2:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[2]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[2]);
                break;
            case 3:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[3]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[3]);
                break;
            case 4:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[4]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[4]);
                break;
            case 5:
                shapeForNewPlanet = Instantiate(shapeSettingsTemplate[5]);
                colorForNewPlanet = Instantiate(colorSettingsTemplate[5]);
                break;
        }

        //print(shapeForNewPlanet.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre);
    }

    public void SetShapeNoise01()
    {
        if(shapeForNewPlanet != null)
        {
            shapeForNewPlanet.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre = Random.insideUnitSphere * Random.Range(1, 100);
            shapeForNewPlanet.noiseLayers[0].noiseSettings.ridgidNoiseSettings.centre = Random.insideUnitSphere * Random.Range(1, 100);
        }
    }
    
    public void SetLandColor(int colorNumber)
    {
        //TODO swtich for all biomes
        colorForNewPlanet.biomeColourSettings.biomes[0].gradient = gradients[colorNumber].gradientColor;
    }

    public void SpawnExtras(int number)
    {
        extraToSpawn = extrasList[number];
    }


    public void SpawnPlanetAction()
    {
        //instance new shape Settings
        //instance new color settings


        myPW.RPC("DoSpawnPlanet", RpcTarget.All, shapeForNewPlanet, colorForNewPlanet, extraToSpawn);
    }

    [PunRPC]
    public void DoSpawnPlanet(ColourSettings colorSettings, ShapeSettings shapeSettings, GameObject goToSpawn)
    {
        var go = Instantiate(prefabPlanet, null);

        //set settings


        go.GetComponent<Planet>().GeneratePlanet();
        
    }
}
