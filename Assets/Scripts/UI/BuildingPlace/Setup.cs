using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Setup : MonoBehaviour
{
    public void OnPointerClick(BaseEventData eventData)
    {
        Debug.Log("Click");
    }
    void Start()
    {
        // T�m Event Trigger component ho?c th�m n?u ch?a c�
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            eventTrigger = gameObject.AddComponent<EventTrigger>();
        }

        // T?o m?t Entry m?i ?? x? l� s? ki?n Pointer Click
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick; // Lo?i s? ki?n: Pointer Click

       
        //EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
       
        //triggerEvent.AddListener((eventData) => GetComponent<BuildPlace>().OnPointerClick((PointerEventData)eventData));
        //entry.callback = triggerEvent;

        entry.callback.AddListener(OnPointerClick);
        // Th�m Entry v�o Event Trigger
        eventTrigger.triggers.Add(entry);
    }
}
