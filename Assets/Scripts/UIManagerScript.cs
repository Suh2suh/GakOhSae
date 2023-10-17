using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    Image lifebar;
    Image energybar;

    Text scoretxt;
    void Start()
    {
        lifebar = GameObject.Find("LifeBar").GetComponent<Image>();              //이미지 갱신을 위해 LifeBar의 이미지 컴포넌트 불러오기
        energybar = GameObject.Find("EnergyBar").GetComponent<Image>();  //이미지 갱신을 위해 EnergyBar의 이미지 컴포넌트 불러오기
        scoretxt = GameObject.Find("TxtScoreNum").GetComponent<Text>();    //텍스트 갱신을 위해 TxtScoreNum의 텍스트 컴포넌트 불러오기
    }

    void Update()
    {  //<계속해서 UI 갱신>
        LifeBarUI();
        EnergyUI();
        ScoreUI();
    }

    void LifeBarUI()     //남은 라이프의 정도만큼 라이프바의 이미지 길이를 갱신하는 함수
    {
        lifebar.fillAmount = GameManager.life / 10f;       //남은 라이프 / 10만큼 갱신
    }

    void EnergyUI()   //플레이어가 점프하는 에너지를 표시하는 에너지바를 갱신하는 함수
    {
        energybar.fillAmount = (float)GameObject.Find("Bar_Gago").GetComponent<CharacterScript>().speed / 6.0f;  
    }                                                                                //ㄴ에너지의 크기만큼 에너지바를 늘림

    void ScoreUI()     //플레이어의 게임 점수 표시 텍스트를 갱신하는 함수
    {  
        scoretxt.text = GameManager.score.ToString();  //표시 텍스트를 현재 점수로 갱신
    }
}
