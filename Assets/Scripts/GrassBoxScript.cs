using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBoxScript : MonoBehaviour, IScore
{
    public bool isExit;                  //�� ���� �ⱸ ������
    public int boxscore = 900;    //�ⱸ ���� �� ���� ����
    GameObject gm;                   //���ӸŴ��� ������Ʈ gm

    private void Start()
    {
        gm = GameObject.Find("GameManager");    //���ӸŴ��� ������Ʈ �ҷ����� 
    }
    public virtual void GetScore()                                  //IScore�� �Լ� GetScore(). �÷��̾�� ���� �ο�
    {
        if (isExit)
        {
            GameManager.score += boxscore;                                //���ھ boxscore��ŭ ��½�Ű��
            gm.GetComponent<GameManager>().NextStage();   //���� ���������� �̵�
        }
    }
}
