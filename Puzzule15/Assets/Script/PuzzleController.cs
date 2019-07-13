using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{

    int[] ClearPiecePos = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    int[] NowPiecePos   = new int[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

    public GameObject selectPiece;

    [SerializeField]
    private GameObject pieceRootObj;
    private GameObject[] allPieceObj = new GameObject[16];

    [SerializeField]
    private Material mat;




    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Init()
    {
        //  ピースの表示
        pieceRootObj.SetActive(true);
        pieceRootObj.transform.position -= new Vector3(1.5f, 0, 1.5f);
        //  各ピースの移動・テクスチャの設定
        for (int i = 0; i < 16; i++)
        {
            allPieceObj[i] = pieceRootObj.transform.GetChild(i).gameObject;
            int ans = i / 4;
            int rem = i % 4;
            //Debug.Log("Ans : " + ans + "| rem : " + rem);
            //  移動
            StartCoroutine(MovePos(allPieceObj[i], allPieceObj[i].transform.position + new Vector3(rem, 0, ans)));

            //allPieceObj[i].transform.position += new Vector3(rem, 0, ans);
            //allPieceObj[i].transform.position -= new Vector3(1.5f, 0, 1.5f);

            //  テクスチャの設定
            Renderer renderer = allPieceObj[i].transform.GetChild(0).GetComponent<Renderer>();
            renderer.material = mat;
            renderer.material.SetTextureScale("_MainTex", new Vector2(0.25f, 0.25f));
            renderer.material.SetTextureOffset("_MainTex", new Vector2(rem * 0.25f, ans * 0.25f));
        }
        Debug.Log("Length : " + allPieceObj.Length);
        //  右下のピースの非表示
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


    void CheckClear()
    {
        if (ClearPiecePos == NowPiecePos)
        {
            Debug.Log("Clear");
        }
    }

    void MovePiece()
    {
        if (selectPiece != null)
        {
            Debug.Log("選択中のオブジェクト" + selectPiece.name);
        }
    }
}
