using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour
{
    public int selectNum = -1;

    // Start is called before the first frame update
    void Start()
    {
        EventTrigger currentTrigger = GetComponent<EventTrigger>();
        currentTrigger.triggers = new List<EventTrigger.Entry>();
        //↑ここでAddComponentしているので一応、初期化しています。

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick; //PointerClickの部分は追加したいEventによって変更してね
        entry.callback.AddListener((x) => SetPieceObject());  //ラムダ式の右側は追加するメソッドです。

        currentTrigger.triggers.Add(entry);
    }


    void Update()
    {
        
    }

    public void SetPieceObject()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        obj.GetComponent<PuzzleController>().selectPiece = gameObject;
    }
}
