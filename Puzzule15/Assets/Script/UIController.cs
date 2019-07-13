using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private FlagController flagController;
    private PuzzleController puzzleController;

    [SerializeField]
    private GameObject StartButtonUI;

    void Awake()
    {
        if (GetComponent<FlagController>() != null)
            flagController = GetComponent<FlagController>();
        if (GetComponent<PuzzleController>() != null)
            puzzleController = GetComponent<PuzzleController>();

        StartButtonUI.GetComponent<Button>().onClick.AddListener(PushStartButton);
    }


    // Update is called once per frame
    void Update()
    {
        CheckPlayFlag();
    }

    bool m_isPlay = false;

    void CheckPlayFlag()
    {
        if (m_isPlay != flagController.Isplay)
        {
            m_isPlay = flagController.Isplay;
            DisplayStartButton(m_isPlay);
        }
    }

    /// <summary>
    /// スタートボタンの表示・非表示
    /// </summary>
    /// <param name="flag"></param>
    void DisplayStartButton(bool flag)
    {
        StartButtonUI.SetActive(!flag);
    }

    public void PushStartButton()
    {
        flagController.Isplay = true;
        puzzleController.Init();
    }

    public void TTTT()
    {
        Debug.Log("VVV");
    }
}
