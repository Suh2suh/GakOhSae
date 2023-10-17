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
        lifebar = GameObject.Find("LifeBar").GetComponent<Image>();              //�̹��� ������ ���� LifeBar�� �̹��� ������Ʈ �ҷ�����
        energybar = GameObject.Find("EnergyBar").GetComponent<Image>();  //�̹��� ������ ���� EnergyBar�� �̹��� ������Ʈ �ҷ�����
        scoretxt = GameObject.Find("TxtScoreNum").GetComponent<Text>();    //�ؽ�Ʈ ������ ���� TxtScoreNum�� �ؽ�Ʈ ������Ʈ �ҷ�����
    }

    void Update()
    {  //<����ؼ� UI ����>
        LifeBarUI();
        EnergyUI();
        ScoreUI();
    }

    void LifeBarUI()     //���� �������� ������ŭ ���������� �̹��� ���̸� �����ϴ� �Լ�
    {
        lifebar.fillAmount = GameManager.life / 10f;       //���� ������ / 10��ŭ ����
    }

    void EnergyUI()   //�÷��̾ �����ϴ� �������� ǥ���ϴ� �������ٸ� �����ϴ� �Լ�
    {
        energybar.fillAmount = (float)GameObject.Find("Bar_Gago").GetComponent<CharacterScript>().speed / 6.0f;  
    }                                                                                //���������� ũ�⸸ŭ �������ٸ� �ø�

    void ScoreUI()     //�÷��̾��� ���� ���� ǥ�� �ؽ�Ʈ�� �����ϴ� �Լ�
    {  
        scoretxt.text = GameManager.score.ToString();  //ǥ�� �ؽ�Ʈ�� ���� ������ ����
    }
}
