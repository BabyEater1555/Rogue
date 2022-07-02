using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenelator : MonoBehaviour
{
    // ���iX���j�̃I�u�W�F�N�g��(3�ȏ�)
    const int MAX_HORIZONTAL = 10;
    // �c�iY���j�̃I�u�W�F�N�g��(3�ȏ�)
    const int MAX_VERTICAL = 10;
    // �N�_�l
    const int BASE_POINT = 1;
    // ���iX���j�̃I�u�W�F�N�g�p�ϐ�
    private int horizontal = MAX_HORIZONTAL;
    // �c�iY���j�̃I�u�W�F�N�g�p�ϐ�
    private int vertical = MAX_VERTICAL;

    // �v���n�u�i�[�p
    public GameObject cube;
    public GameObject miner;

    // Start is called before the first frame update
    void Start()
    {
        CubeGenelator(cube);

        // �X�^�[�g�ʒu�̌���
        Vector2 startPos = DecidePoint();

        //�S�[���ʒu�̌���
        Vector2 goalPos = DecidePoint();

        Debug.Log("�X�^�[�g�n�_�F" + startPos);
        Debug.Log("�S�[���n�_�F" + goalPos);

        while ((startPos.x == goalPos.x && (startPos.y == goalPos.y || startPos.y + 1 == goalPos.y || startPos.y - 1 == goalPos.y)) || (startPos.y == goalPos.y && (startPos.x == goalPos.x || startPos.x + 1 == goalPos.x || startPos.x - 1 == goalPos.x)))
        {
            goalPos = DecidePoint();
            Debug.Log("�S�[���n�_�Đ����F" + goalPos);
        }

        GameObject startCube = GameObject.Find(startPos.y + "-" + startPos.x);
        startCube.GetComponent<Renderer>().material.color = Color.blue;
        GameObject goalCube = GameObject.Find(goalPos.y + "-" + goalPos.x);
        goalCube.GetComponent<Renderer>().material.color = Color.red;
    }

    private void CubeGenelator(GameObject obj)
    {
        // ��ʒu�̐ݒ�
        Vector3 pos = new Vector3(0, 0, 0);

        // ��`����Y���̃I�u�W�F�N�g�ʂ���cube����ׂ�
        for (int ver = 1; ver <= vertical; ver++)
        {
            // ��`����X���̃I�u�W�F�N�g�ʂ���cube����ׂ�
            for (int hor = 1; hor <= horizontal; hor++)
            {
                // Prefab��Cube�𐶐�
                GameObject copyObj = Instantiate(obj);

                // ���������I�u�W�F�N�g�ɖ��O��t����
                copyObj.name = ver.ToString() + "-" + hor.ToString();

                // ���������I�u�W�F�N�g���ړ�������
                copyObj.transform.position = new Vector2(pos.x + hor, pos.y + ver);
            }
        }
    }

    private Vector2 DecidePoint()
    {
        // �����_���ȊO���ʒu�i�l���������j�̌���
        int pointVertical = Random.Range(BASE_POINT, vertical + 1);
        int pointHorizontal;
        switch (pointVertical)
        {
            case BASE_POINT:
                pointHorizontal = Random.Range(BASE_POINT + 1, horizontal);
                break;
            case MAX_VERTICAL:
                pointHorizontal = Random.Range(BASE_POINT + 1, horizontal);
                break;
            default:
                int val = Random.Range(0, 2);
                if (val == 0)
                {
                    pointHorizontal = BASE_POINT;
                }
                else
                {
                    pointHorizontal = horizontal;
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
