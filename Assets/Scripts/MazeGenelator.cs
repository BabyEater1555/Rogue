using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenelator : MonoBehaviour
{
    // 横（X軸）のオブジェクト量
    public int horizontal = 15;
    // 縦（Y軸）のオブジェクト量
    public int vertical = 15;
    // 起点値
    public int basePoint = 1;

    // プレハブ格納用
    public GameObject cube;
    public GameObject miner;

    // Start is called before the first frame update
    void Start()
    {
        CubeGenelator(cube);

        // スタート位置の決定
        Vector2 startPos = DecidePoint();

        //ゴール位置の決定
        Vector2 goalPos = DecidePoint();

        Debug.Log("スタート地点：" + startPos);
        Debug.Log("ゴール地点：" + goalPos);

        while ((startPos.x == goalPos.x && (startPos.y == goalPos.y || startPos.y + 1 == goalPos.y || startPos.y - 1 == goalPos.y)) || (startPos.y == goalPos.y && (startPos.x == goalPos.x || startPos.x + 1 == goalPos.x || startPos.x - 1 == goalPos.x)))
        {
            goalPos = DecidePoint();
            Debug.Log("ゴール地点再生成：" + goalPos);
        }

        GameObject startCube = GameObject.Find(startPos.y + "-" + startPos.x);
        startCube.GetComponent<Renderer>().material.color = Color.blue;
        GameObject goalCube = GameObject.Find(goalPos.y + "-" + goalPos.x);
        goalCube.GetComponent<Renderer>().material.color = Color.red;
    }

    private void CubeGenelator(GameObject obj)
    {
        // 基準位置の設定
        Vector3 pos = new Vector3(0, 0, 0);

        // 定義したY軸のオブジェクト量だけcubeを並べる
        for (int ver = 1; ver <= vertical; ver++)
        {
            // 定義したX軸のオブジェクト量だけcubeを並べる
            for (int hor = 1; hor <= horizontal; hor++)
            {
                // PrefabのCubeを生成
                GameObject copyObj = Instantiate(obj);

                // 生成したオブジェクトに名前を付ける
                copyObj.name = ver.ToString() + "-" + hor.ToString();

                // 生成したオブジェクトを移動させる
                copyObj.transform.position = new Vector2(pos.x + hor, pos.y + ver);
            }
        }
    }

    private Vector2 DecidePoint()
    {
        // ランダムな外周位置（四隅を除く）の決定
        int pointHorizontal = Random.Range(basePoint, horizontal + 1);
        int pointVertical = 0;
        switch (pointHorizontal)
        {
            case 1:
                pointVertical = Random.Range(basePoint + 1, vertical);
                break;
            case 15:
                pointVertical = Random.Range(basePoint + 1, vertical);
                break;
            default:
                int val = Random.Range(0, 2);
                if (val == 0)
                {
                    pointVertical = basePoint;
                }
                else
                {
                    pointVertical = vertical;
                }
                break;
        }
        return new(pointHorizontal, pointVertical);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
