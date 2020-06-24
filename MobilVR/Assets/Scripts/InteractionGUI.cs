using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionGUI : MonoBehaviour { 


    public GameObject SelectedObject;
    public GameObject TopicCanvas;

    private float timer;
    public float gazeTime = 2f;
    private bool gazedAt;
    private float sizze = 1.5F;


    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;
            Transform child = transform.GetChild(0);
            Vector3 newScale = new Vector3(timer / gazeTime* sizze, timer / gazeTime* sizze, timer / gazeTime* sizze);

            child.localScale = newScale;

            if(timer >= gazeTime)
            {
                timer = 0f;
                selectBubble();
                //ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }
        }
    }

    public void BubbleIn()
    {
        gazedAt = true;
        //trigger loading animation (2sec)

    }

    public void BubbleOut()
    {
        gazedAt = false;


    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
       // Destroy(SelectedObject);


    }

    private void selectBubble()
    {

        TopicCanvas.SetActive(true);
        SelectedObject.SetActive(false);
    //Destroy(SelectedObject);

    }
}
