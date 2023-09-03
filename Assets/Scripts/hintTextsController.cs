using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hintTextsController : MonoBehaviour
{
    public GameObject HintTexts, Text, InputSystem, rBtn, lBtn, Avatar, Option, showChatBtn, chatManager;

    bool _lineMode;
    


    // Start is called before the first frame update
    private void Awake()
    {
        HintTexts = GameObject.FindWithTag("hintTexts");
        Text = HintTexts.transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        Text.GetComponent<Text>().text = "";
        HintTexts.SetActive(false);
        ChangeLineMode(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 讓手機顯示新文字
    /// </summary>
    public void newText(string newText)
    {
        if (_lineMode)
        {
            nextLine();
        }
        else
        {
            if (HintTexts.activeSelf == false)
            {
                HintTexts.SetActive(true);
                Text.GetComponent<Text>().text = newText;
            }
            else if (!CheckIfClickedInsideInput())
            {
                SetActiveFalse();
            }
        }
    }
    /// <summary>
    /// 讓手機顯示新文字，出現YNbutton，按下後觸發設定好的Event
    /// </summary>
    /// <param name="id">
    /// YNbutton，按下後觸發設定好的Event
    /// </param>
    public void newYN(string newText, int event_id = -1)
    {
        if (_lineMode)
        {
            nextLine();
        }
        else
        {
            if (HintTexts.activeSelf == false)
            {
                HintTexts.SetActive(true);
                gameObject.GetComponent<ynButtonController>().showYNButtons();
                gameObject.GetComponent<ynButtonController>().SetEventID(event_id);
                Text.GetComponent<Text>().text = newText;
            }
            else if (!CheckIfClickedInsideInput())
            {
                SetActiveFalse();
            }
        }

    }

    public void newInput(string newText, int event_id = -1)
    {
        if (_lineMode)
        {
            nextLine();
        }
        else
        {
            if (HintTexts.activeSelf == false)
            {
                HintTexts.SetActive(true);
                InputSystem.SetActive(true);
                Text.GetComponent<Text>().text = newText;
            }
            else if (!CheckIfClickedInsideInput())
            {
                SetActiveFalse();
            }
        }

    }

    public void newOption(List<string> option_list)
    {
        Option.SetActive(true);
        Option.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = option_list[0];
        Option.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = option_list[1];
        Option.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = option_list[2];
        Option.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = option_list[3];
    }

    private void OnMouseDown()
    {
        Debug.Log("點擊空白");
        if (_lineMode)
        {
            nextLine();
        }
        else
        {
            SetActiveFalse();
        }
    }

    public void nextLine()
    {
        string nowline = gameObject.GetComponent<linesController>().ReadLineFromList();
        if(nowline == "end.")
        {
            ChangeLineMode(false);
        }
        else
        {
            HintTexts.SetActive(true);
            ChangeTextContent(nowline);
        }
        
    }

    public void ChangeLineMode(bool mode)
    {
        if(mode == true) nextLine();
        _lineMode = mode;
        HintTexts.SetActive(mode);
        Avatar.SetActive(mode);
        rBtn.SetActive(!mode);
        lBtn.SetActive(!mode);
        showChatBtn.SetActive(!mode);
    }

    public void ChangeTextSize(int newSize)
    {
        Text.GetComponent<Text>().fontSize = newSize;
    }

    public void ChangeTextContent(string newText)
    {
        Text.GetComponent<Text>().text = newText;
    }

    void SetActiveFalse()
    {
        gameObject.GetComponent<ynButtonController>().unShowYNButtons();
        InputSystem.SetActive(false);
        HintTexts.SetActive(false);
    }

    bool CheckIfClickedInsideInput()
    {
        if (InputSystem.activeSelf == true && InputSystem.GetComponent<passwordInput>().isPointerInside == true)
            return true;
        return false;
    }

    /// <summary>
    /// 顯示聊天室
    /// </summary>
    public void ShowChatManager()
    {
        chatManager.SetActive(!chatManager.activeInHierarchy);
    }

}
