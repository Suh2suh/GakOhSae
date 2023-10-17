using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBoxScript : MonoBehaviour, IScore
{
    public bool isExit;                  //이 블럭이 출구 블럭인지
    public int boxscore = 900;    //출구 블럭일 때 얻을 점수
    GameObject gm;                   //게임매니저 오브젝트 gm

    private void Start()
    {
        gm = GameObject.Find("GameManager");    //게임매니저 오브젝트 불러오기 
    }
    public virtual void GetScore()                                  //IScore의 함수 GetScore(). 플레이어에게 점수 부여
    {
        if (isExit)
        {
            GameManager.score += boxscore;                                //스코어를 boxscore만큼 상승시키고
            gm.GetComponent<GameManager>().NextStage();   //다음 스테이지로 이동
        }
    }
}
