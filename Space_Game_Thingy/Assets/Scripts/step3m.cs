using UnityEngine;
using UnityEngine.EventSystems;

public class step3m : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private TutorialController tutorialcontroller;
    private int touchID;

    private void Start()
    { 
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            tutorialcontroller = GameControllerObject.GetComponent<TutorialController>();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        touchID = eventData.pointerId;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (touchID == eventData.pointerId)
        {
            tutorialcontroller.Step3m();
        }
    }
}
