using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TouchPadToStory : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool touched;
    private int pointerID;
    void Awake()
    {
        touched = false;
    }
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (!touched)
        {
            touched = true;
            pointerID = eventData.pointerId;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId == pointerID)
        {
            SceneManager.LoadScene("Story_Scene");
        }
    }
}
