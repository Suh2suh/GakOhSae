using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBoxScript : GrassBoxScript, IScore
{
    public override void GetScore()      //GrassBoxScript�� GetScore()�� �������̵�
    {
        boxscore = 1200;                          //boxscore�� 900���� 1200���� ����
        base.GetScore();
    }
}
