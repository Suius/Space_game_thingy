using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TouchPadToTutorial : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    private bool touched;
    private int pointerID;
    public bool activated;

    void Awake()
    {
        touched = false;
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (pointerID == data.pointerId)
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
}
