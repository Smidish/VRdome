using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropOnTable : MonoBehaviour
{

    private bool lookedat;
    private float timer;
    private float grabTime;

    public bool DropObj;
    // Start is called before the first frame update
    void Start()
    {
        lookedat = false;
        DropObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lookedat)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer >= grabTime)
            {
                dropObj();
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
    }

    private void dropObj()
    {
        DropObj = true;
    }
}
