using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CreatePlanetOnWeb : MonoBehaviour
{
    public Planet myPlanet;

    public void Start()
    {
        myPlanet = GetComponent<Planet>();
        myPlanet.GeneratePlanet();
        transform.position = new Vector3(0, -500, -500);
    }

    public void DoSetShape(ShapeSettings shapes)
    {
        myPlanet.shapeSettings = shapes;
    }

    public void DoSetColors(ColourSettings colors)
    {
        myPlanet.colourSettings = colors;
    }

    public void RandomizeSettings()
    {
        myPlanet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.strength = UnityEngine.Random.Range(0.05f, .8f);
        myPlanet.shapeSettings.noiseLayers[0].noiseSettings.simpleNoiseSettings.centre = UnityEngine.Random.insideUnitSphere * UnityEngine.Random.Range(1f, 100f);
        myPlanet.GeneratePlanet();
    }
}
