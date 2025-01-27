using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    static public clue clue;
    static public eventController eventController;
    static public scenesController scenesController;
    static public hintTextsController hintTexts;

    public GameObject _GameUI;
    public GameObject _clue;

    private void Awake()
    {
        clue = _clue.GetComponent<clue>();
        eventController = _GameUI.GetComponent<eventController>();
        scenesController = _GameUI.GetComponent<scenesController>();
        hintTexts = _GameUI.GetComponent<hintTextsController>();
    }
}
