using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{

    public Text NameOfTheGame;

    void Start()
    {
        NameOfTheGame.text = "Star Invasion X";
    }
}