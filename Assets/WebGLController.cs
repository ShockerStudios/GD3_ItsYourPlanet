using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGLController : MonoBehaviour
{
    public bool hideControlls;
    private void Start()
    {
        if (hideControlls)
        {
            HideTheseControls();
        }
        
    }

    public void HideTheseControls()
    {
        if(Application.platform != RuntimePlatform.WebGLPlayer)
        {
            gameObject.SetActive(false);
        }
    }
}
