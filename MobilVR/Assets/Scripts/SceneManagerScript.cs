using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject Mic;
    public GameObject Cam;
    public GameObject Notes;
    public GameObject Handy;

    public List<GameObject> selObjs;
    public GameObject droppedObject;

    public bool SomethingIsCarried;


    // Start is called before the first frame update
    void Start()
    {
        SomethingIsCarried = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(droppedObject);
    }

    public void ItemsCombined()
    {
        Debug.Log("Items combined!");
        resetAll();
    }

    public void ItemDropped()
    {
        selObjs.Add(droppedObject);
        if(selObjs.Count == 2)
        {           
            ItemsCombined();
        }

    }

    public void resetAll()
    {
        selObjs.Clear();
    }
}
