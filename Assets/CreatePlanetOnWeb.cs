using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanetOnWeb : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Planet>().GeneratePlanet();
        transform.position = new Vector3(0, -500, -500);
    }
}
