using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyScript : MonoBehaviour, ILucky
{
    int luckpt;                              //나무에서 얻을 수 있는 점수
    public void GetLuck()
    { 
        luckpt = Random.Range(100, 1000);   //100부터 1000 사이의 랜덤 값을 luckpt로 설정
        GameManager.score += luckpt;           //설정된 luckpt를 플레이어 스코어에 증가
    }
}
