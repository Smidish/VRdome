using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionGUI : MonoBehaviour { 


    public GameObject SelectedObject;
    public GameObject TopicCanvas;
    public Material dissolveMat;

    private float timer = 1f;
    public float gazeTime = 3f;
    private bool gazedAt;
    private float sizze = 1F;

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
            Vector3 newScale = new Vector3(timer / gazeTime* sizze, timer / gazeTime* sizze, timer / gazeTime* sizze);
                       
            child.localScale = newScale;
            dissolveMat.SetFloat("TimeActivation", gazeTime * dissolveInt);

            if (timer >= gazeTime)
            {
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
        gazedAt = false;
        timer = 1f;
        Transform child = transform.GetChild(0);
        child.localScale = defaultScale;
        Debug.Log(defaultScale);
        SelectedObject.SetActive(true);

    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
       // Destroy(SelectedObject);
    }

    private void selectBubble()
    {
        SelectedObject.SetActive(false);
          TopicCanvas.SetActive(true);
        
    //Destroy(SelectedObject);

    }
}
