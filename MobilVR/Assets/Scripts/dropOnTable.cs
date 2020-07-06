using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOnTable : MonoBehaviour
{

    private bool lookedat;
    private float timer;
    public float grabTime = 2f;

    public bool DropObj;
    private GameObject sceneMan;
    // Start is called before the first frame update
    void Start()
    {
        sceneMan = GameObject.Find("SceneManager");
        lookedat = false;
        timer = 0;
        DropObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookedat && sceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= grabTime)
            {
                dropObj();
                return;
            }
        }
    }

    public void LookedAtTable()
    {
        lookedat = true;
    }

    public void NotLookedAtTable()
    {
        lookedat = false;
        DropObj = false;
        timer = 0;
    }

    private void dropObj()
    {
        DropObj = true; //in grab funktion
        lookedat = false;
        timer = 0;
        sceneMan.GetComponent<SceneManagerScript>().SomethingIsCarried = false;
        Debug.Log("dropOnTableDrop");
    }
}
