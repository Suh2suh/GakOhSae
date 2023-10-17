using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;  //게임매니저 스크립트를 instance로 받아온다

    static public long score = 0;                              //시작 스코어 = 0
    static public int life = 10;                                    //남은 라이프 (10이 끝), 죽을 때마다 시작 위치로
    public string userdatas;                                     //유저의 이름을 받아올 string 클래스(문자열)
    List<string> scenelist = new List<string>();    //씬 목록을 담을 string타입 리스트 "scenelist"
    private void Awake()
    {
        if(instance == null)   //<싱글톤 패턴> (한 프로젝트에 단 하나의 게임오브젝트만 있도록 하는 패턴)
        {                                 //만약 게임 매니저 스크립트가(오브젝트가) 현재 씬에 없다면,
            instance = this;    //이 스크립트(오브젝트)를 instance에 넣는다(instance가 이 스크립트로 변경)
            DontDestroyOnLoad(this.gameObject);   //그리고, 이 스크립트가 있는 오브젝트(게임메이커)를 씬을 이동했을 때에도 파괴시키지 않는다
        }
        else                                            //만약 이미 게임매니저 스크립트(오브젝트)가 이 씬에 존재한다면, (instance가 찼다면)
        {
            Destroy(this.gameObject);  //이 오브젝트를 제거하고 다른 오브젝트는 그대로 남겨놓는다
        }
    }

    private void Start()
    {                                                     //게임 메이커가 처음 만들어졌을 때 (메인 게임 시작 할 때)
        for(int i = 0; i < 3; i++)               //스테이지들을 리스트에 차례대로 담는다
        {
            scenelist.Add("Stage" + (i+1).ToString());
        }
    }

    public void EndGame()     //<게임을 끝내는 함수>: 점수 표시 씬으로 이동한다
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void NextStage()    //<다음 스테이지로 이동하는 함수>
    {
        switch(SceneManager.GetActiveScene().buildIndex)   //씬 빌딩 인덱스 순서로 조건문을 만들었다
        {
            case 1:                //만약 현재 씬의 빌드인덱스 넘버가 1이면, (첫번째 스테이지면)
                SceneManager.LoadScene(scenelist[1]);    //두번째 스테이지로 이동
                break;
            case 2:                //만약 현재 씬의 빌드인덱스 넘버가 2면, (두번째 스테이지면)
                SceneManager.LoadScene(scenelist[2]);    //세번째 스테이지로 이동
                break;
            case 3:                //만약 현재 씬의 빌드인덱스 넘버가 3이면, (3번째 스테이지면)                
                EndGame();                                                      //게임을 종료(점수 표시 씬으로 이동)
                break;
            default:
                break;
        }
    }
}