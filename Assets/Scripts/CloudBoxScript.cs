using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoxScript : GrassBoxScript, IScore
{
    public override void GetScore()      //GrassBoxScript의 GetScore()을 오버라이드
    {
        boxscore = 1500;                          //boxscore을 900에서 1500으로 변경
        base.GetScore();
    }
}
