using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoxScript : GrassBoxScript, IScore
{
    public override void GetScore()      //GrassBoxScript�� GetScore()�� �������̵�
    {
        boxscore = 1500;                          //boxscore�� 900���� 1500���� ����
        base.GetScore();
    }
}
