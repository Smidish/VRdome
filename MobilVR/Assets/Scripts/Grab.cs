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
    Rigidbody _rb;

    private void Start()
    {
        lookedat = false;
        carried = false;
        gazePoint = GameObject.Find("GvrReticlePointer");
        //ringanimation = GameObject.Find("coolparticles");
        _rb = selObj.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (lookedat)
        {
            timer += Time.deltaTime;
            if (timer >= grabTime || carried)
            {
                GrabStart();
            }
        }
        if (table.GetComponent<dropOnTable>().DropObj && carried)
        {
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
        //Vector3 offsetX = new Vector3(2,0,-1);
        //Ray ray = new Ray(gazePoint.transform.position, gazePoint.transform.forward);
        //transform.position = ray.GetPoint(4);

        selObj.transform.SetParent(PlayerHand.transform);
        selObj.transform.localPosition = new Vector3(0f,0.1f,0f);
        _rb.isKinematic = true;
        carried = true;

        
        Debug.Log(ringanimation);
        ringanimation.SetActive(true);
    }
    private void GrabEnd()
    {
        //Ray ray = new Ray(gazePoint.transform.position, gazePoint.transform.forward);
        selObj.transform.SetParent(GameObject.Find("Interaction").transform);
        transform.position = transform.position;
        Debug.Log("drop");
        carried = false;
        lookedat = false;
        timer = 0f;
        _rb.isKinematic = false;
    }
}
