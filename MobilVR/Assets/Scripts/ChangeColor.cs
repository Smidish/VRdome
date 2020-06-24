using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Material dissolveMat;

    public void DissolveIn() {
        Debug.Log("hi");
        dissolveMat.SetFloat("TimeActivation", 0);
        
    }

    public void DissolveOut()
    {
        Debug.Log("hi");
        dissolveMat.SetFloat("TimeActivation", 1);
        
    }


    public void Red()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    public void Black()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }
}
