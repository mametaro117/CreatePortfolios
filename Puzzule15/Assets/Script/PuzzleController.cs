using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    private int[] allPieceNum = new int[16];
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private GameObject pieceRootObj;
    private GameObject[] allPieceObj = new GameObject[16];

    [SerializeField]
    private Texture catImage;
    [SerializeField]
    private Material mat;

    void Awake()
    {
        //Init();
        startButton.onClick.AddListener(Init);
    }



    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Init()
    {
        pieceRootObj.SetActive(true);
        pieceRootObj.transform.position -= new Vector3(1.5f, 0, 1.5f);
        for (int i = 0; i < 16; i++)
        {
            allPieceObj[i] = pieceRootObj.transform.GetChild(i).gameObject;
            int ans = i / 4;
            int rem = i % 4;
            //Debug.Log("Ans : " + ans + "| rem : " + rem);
            StartCoroutine(MovePos(allPieceObj[i], allPieceObj[i].transform.position + new Vector3(rem, 0, ans)));
            //allPieceObj[i].transform.position += new Vector3(rem, 0, ans);
            //allPieceObj[i].transform.position -= new Vector3(1.5f, 0, 1.5f);
            Renderer renderer = allPieceObj[i].transform.GetChild(0).GetComponent<Renderer>();
            renderer.material = mat;
            renderer.material.SetTextureScale("_MainTex", new Vector2(0.25f, 0.25f));
            renderer.material.SetTextureOffset("_MainTex", new Vector2(rem * 0.25f, ans * 0.25f));
        }
        Debug.Log("Length : " + allPieceObj.Length);
        allPieceObj[allPieceObj.Length - 1].SetActive(false);
    }

    IEnumerator MovePos(GameObject obj, Vector3 targetPos)
    {
        float time = 0;
        float animTime = 1;
        Vector3 pos = obj.transform.position;
        while (time <= animTime)
        {
            obj.transform.position = Vector3.Slerp(pos, targetPos, time / animTime);
            time += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = targetPos;
        yield break;
    }
}
