using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TalkText;
    public GameObject scanObject;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        TalkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
    }
}
