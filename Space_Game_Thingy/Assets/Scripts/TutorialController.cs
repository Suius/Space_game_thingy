using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    public Text StepOne;
    public Text StepTwo;
    public Text StepThree;
    private bool stepTwo, stepThree;


    private void Start()
    {
        StepOne.text = "Welcome to the game! See that joystick-like thing in the bottom left corner? Drag it to control your movement. Touch this text to go to the next part of the tutorial.";
        StepTwo.text = "";
        StepThree.text = "";
        stepTwo = false;
        stepThree = false;
    }
    public void Step12()
    {
        StepOne.text = "";
        StepTwo.text = "Now, on your bottom right corner, you can see a fire button. Hold it to shoot repeatedly. Touch this when you're done.";
        stepTwo = true;
    }
    public void Step23()
    {
        if (stepTwo == true)
        {
            StepTwo.text = "";
            StepThree.text = "Congratulations, you can now play this game, although I'm pretty sure you could do that even without my help but whatever. Touch this text to exit the tutorial.";
            stepThree = true;
        }
    }
    public void Step3m()
    {
        if (stepThree == true)
        {
            SceneManager.LoadScene("mainMenu");
        }
    }
}

