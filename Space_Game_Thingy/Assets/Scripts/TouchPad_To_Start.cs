using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TouchPad_To_Start : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool touched;
    private int pointerID;
    
	void Awake()
    {
        touched = false;
    }
	
	public void OnPointerDown (PointerEventData data)
    {
        if (!touched)
        {
            touched = true;
            pointerID = data.pointerId;
        }
    }
    public void OnPointerUp (PointerEventData data)
    {
        if (data.pointerId == pointerID)
        {
            SceneManager.LoadScene("Some_Scene");
        }
    }
}
