using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBoxScript : GrassBoxScript, IScore
{
    public override void GetScore()      //GrassBoxScript의 GetScore()을 오버라이드
    {
        boxscore = 1200;                          //boxscore을 900에서 1200으로 변경
        base.GetScore();
    }
}
