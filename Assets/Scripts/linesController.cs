//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class linesController : MonoBehaviour
{
    public GameObject Avatar;
    public int nowFile;
    public int nowLine;
    public string nowName;
    public string nowOptionID;

    public Sprite Player1;
    public Sprite Player2;
    public Sprite Unknown;

    public List<TextAsset> fileList = new List<TextAsset>();
    private List<string> textList = new List<string>();

    private void Awake()
    {
        GetTextFormFile(fileList[0]);
        nowFile = 0;
        nowLine = 0;
    }
    void GetTextFormFile(TextAsset file)
    {

        textList.Clear();
        var lineData = file.text.Split('\n');

        foreach (var line in lineData) 
        {
            textList.Add(line);
        }
    }

    public string ReadLineFromList()
    {
        string nowLineStr = textList[nowLine];

        if (nowLineStr.IndexOf('�G') != -1 && nowLineStr.Substring(0, nowLineStr.IndexOf('�G')) == "OPTION")
        {
            Avatar.SetActive(false);
            nowOptionID = nowLineStr.Substring(nowLineStr.IndexOf('�G') + 1);
            gameObject.GetComponent<eventController>().GenerateOptionByStringID(nowOptionID);

            return gameObject.GetComponent<eventController>().GetNowOptionName();
        }
        
        if (nowLineStr.IndexOf('�G') !=-1 && nowLineStr.Substring(0, nowLineStr.IndexOf('�G')) != nowName)
        {
            ChangeAvatar(nowLineStr.Substring(0, nowLineStr.IndexOf('�G')));
            nowName = nowLineStr.Substring(0, nowLineStr.IndexOf('�G'));
        }


        if (textList[nowLine] == "end.")
        {
            return "end.";
        }
        return textList[nowLine++]; 
    }

    public void ChangeAvatar(string chara_name)
    {
        Debug.Log("������");
        Avatar.SetActive(true);
        if (chara_name == "A")
        {
            Avatar.GetComponent<UnityEngine.UI.Image>().sprite = Player1;
            Avatar.GetComponent<RectTransform>().localPosition = new Vector3(-634, 102, 0);
            Avatar.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 0);
        }
        else if (chara_name == "B")
        {
            Avatar.GetComponent<UnityEngine.UI.Image>().sprite = Player2;
            Avatar.GetComponent<RectTransform>().localPosition = new Vector3(634, 102, 0);
            Avatar.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
        }
        else
        {
            Avatar.GetComponent<UnityEngine.UI.Image>().sprite = Unknown;
            Avatar.GetComponent<RectTransform>().localPosition = new Vector3(0, 102, 0);
            Avatar.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 0);
        }
    }
}
