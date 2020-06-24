﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionGUI : MonoBehaviour { 


    public GameObject SelectedObject;
    public GameObject TopicCanvas;
    public Material dissolveMat;
    public float gazeTime = 2f;

    private float timer = 1.1f;
    private bool gazedAt;
    private float sizze = 1.5F;

    private float dissolveInt = 0.9f;
    private Vector3 defaultScale;

    void Start()
    {
        Transform child = transform.GetChild(0);
        defaultScale = child.localScale;
    }
    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            Transform child = transform.GetChild(0);
            Transform child2 = transform.GetChild(1);
            Transform child3 = transform.GetChild(2);
            Vector3 newScale = new Vector3(timer / gazeTime* sizze, timer / gazeTime* sizze, timer / gazeTime* sizze);
            Vector3 newScale2 = new Vector3(timer / gazeTime * sizze-0.1f, timer / gazeTime * sizze - 0.1f, timer / gazeTime * sizze - 0.1f);
            Vector3 newScale3 = new Vector3(0,0,0);
            child.localScale = newScale;
            child2.localScale = newScale2;
            child3.localScale = newScale3;
            dissolveMat.SetFloat("Vector1_BA4DED15", timer/gazeTime * dissolveInt);

            //SelectedObject.GetComponent<Renderer>().material = null;
            //Debug.Log(gazeTime * dissolveInt * -1f);

            if (timer >= gazeTime)
            {
                Debug.Log("hi");
                timer = 1f;
                selectBubble();
                //ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }
        }
    }

    public void BubbleIn()
    {
        gazedAt = true;
    }

    public void BubbleOut()
    {
        //reset size n shit
        gazedAt = false;
        timer = 1f;
        Transform child = transform.GetChild(0);
        child.localScale = defaultScale;
        Debug.Log(defaultScale);
        SelectedObject.SetActive(true);
        dissolveMat.SetFloat("Vector1_BA4DED15", 1);

    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
       // Destroy(SelectedObject);
    }

    private void selectBubble()
    {
        TopicCanvas.SetActive(true);
        TopicCanvas.transform.position = new Vector3(SelectedObject.transform.position.x, 2, SelectedObject.transform.position.z);
        SelectedObject.SetActive(false);      
        
        
    //Destroy(SelectedObject);

    }
}
