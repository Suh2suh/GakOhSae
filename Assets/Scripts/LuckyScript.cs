using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyScript : MonoBehaviour, ILucky
{
    int luckpt;                              //�������� ���� �� �ִ� ����
    public void GetLuck()
    { 
        luckpt = Random.Range(100, 1000);   //100���� 1000 ������ ���� ���� luckpt�� ����
        GameManager.score += luckpt;           //������ luckpt�� �÷��̾� ���ھ ����
    }
}
