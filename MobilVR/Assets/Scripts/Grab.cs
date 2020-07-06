using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject selObj;
    private float timer=0f;
    private float grabTime = 2f;
    private bool lookedat;
    private bool carried;
    private GameObject gazePoint;
    public GameObject table;
    public GameObject PlayerHand;
    public GameObject ringanimation;
    private GameObject SceneMan;
    Rigidbody _rb;

    private void Start()
    {
        lookedat = false;
        carried = false;
        gazePoint = GameObject.Find("GvrReticlePointer");
        //ringanimation = GameObject.Find("coolparticles");
        _rb = selObj.GetComponent<Rigidbody>();
        SceneMan = GameObject.Find("SceneManager");
    }
    private void Update()
    {
        if (lookedat)
        {
            timer += Time.deltaTime;
            if (timer >= grabTime && !SceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried)
            {
                GrabStart();
            }
        }
        if (table.GetComponent<dropOnTable>().DropObj && carried/*SceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried*/)
        {
            Debug.Log("HI from Grab End Grab.cs");
            GrabEnd();    
        }
    }
    public void LookedAt()
    {
        lookedat = true;
    }

    public void NotLookedAt()
    {
        lookedat = false;
        timer = 0f;
    }

    private void GrabStart() {

        selObj.transform.SetParent(PlayerHand.transform);
        selObj.transform.localPosition = new Vector3(0f,0.1f,0f);
        _rb.isKinematic = true;
        carried = true;

        
        Debug.Log("Im lifted!");
        ringanimation.SetActive(true);
        SceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried = true;
        timer = 0f;
    }
    private void GrabEnd()
    {

        //hier schönere Variatne für Drop
        selObj.transform.SetParent(GameObject.Find("Table").transform);
        transform.position = transform.position;
        Debug.Log("drop");
        ringanimation.SetActive(false);
        carried = false;
        //lookedat = false;
        timer = 0f;
        _rb.isKinematic = false;
        SceneMan.GetComponent<SceneManagerScript>().droppedObject = selObj;
        SceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried = false;
    }
}
