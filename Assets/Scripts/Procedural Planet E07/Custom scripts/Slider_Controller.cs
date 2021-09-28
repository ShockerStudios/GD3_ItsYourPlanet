using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Controller : MonoBehaviour
{
    public Planet planet;
    public ShapeSettings shapeSettings;
    public ColourSettings colorSettings;
    public GameObject camRig;
    public Slider zoom;
    public Slider resolutionSlider;
    public Slider diameterSlider;

    private float camRigScale;
    

    //public SliderJoint2D resolutionSlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camRigScale = zoom.value;
        planet.resolution = (int)resolutionSlider.value;
        shapeSettings.planetRadius = (int)diameterSlider.value;
        camRig.transform.localScale = new Vector3(camRigScale, camRigScale, camRigScale);
    }

}
