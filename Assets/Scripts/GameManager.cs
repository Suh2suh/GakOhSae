using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;  //���ӸŴ��� ��ũ��Ʈ�� instance�� �޾ƿ´�

    static public long score = 0;                              //���� ���ھ� = 0
    static public int life = 10;                                    //���� ������ (10�� ��), ���� ������ ���� ��ġ��
    public string userdatas;                                     //������ �̸��� �޾ƿ� string Ŭ����(���ڿ�)
    List<string> scenelist = new List<string>();    //�� ����� ���� stringŸ�� ����Ʈ "scenelist"
    private void Awake()
    {
        if(instance == null)   //<�̱��� ����> (�� ������Ʈ�� �� �ϳ��� ���ӿ�����Ʈ�� �ֵ��� �ϴ� ����)
        {                                 //���� ���� �Ŵ��� ��ũ��Ʈ��(������Ʈ��) ���� ���� ���ٸ�,
            instance = this;    //�� ��ũ��Ʈ(������Ʈ)�� instance�� �ִ´�(instance�� �� ��ũ��Ʈ�� ����)
            DontDestroyOnLoad(this.gameObject);   //�׸���, �� ��ũ��Ʈ�� �ִ� ������Ʈ(���Ӹ���Ŀ)�� ���� �̵����� ������ �ı���Ű�� �ʴ´�
        }
        else                                            //���� �̹� ���ӸŴ��� ��ũ��Ʈ(������Ʈ)�� �� ���� �����Ѵٸ�, (instance�� á�ٸ�)
        {
            Destroy(this.gameObject);  //�� ������Ʈ�� �����ϰ� �ٸ� ������Ʈ�� �״�� ���ܳ��´�
        }
    }

    private void Start()
    {                                                     //���� ����Ŀ�� ó�� ��������� �� (���� ���� ���� �� ��)
        for(int i = 0; i < 3; i++)               //������������ ����Ʈ�� ���ʴ�� ��´�
        {
            scenelist.Add("Stage" + (i+1).ToString());
        }
    }

    public void EndGame()     //<������ ������ �Լ�>: ���� ǥ�� ������ �̵��Ѵ�
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void NextStage()    //<���� ���������� �̵��ϴ� �Լ�>
    {
        switch(SceneManager.GetActiveScene().buildIndex)   //�� ���� �ε��� ������ ���ǹ��� �������
        {
            case 1:                //���� ���� ���� �����ε��� �ѹ��� 1�̸�, (ù��° ����������)
                SceneManager.LoadScene(scenelist[1]);    //�ι�° ���������� �̵�
                break;
            case 2:                //���� ���� ���� �����ε��� �ѹ��� 2��, (�ι�° ����������)
                SceneManager.LoadScene(scenelist[2]);    //����° ���������� �̵�
                break;
            case 3:                //���� ���� ���� �����ε��� �ѹ��� 3�̸�, (3��° ����������)                
                EndGame();                                                      //������ ����(���� ǥ�� ������ �̵�)
                break;
            default:
                break;
        }
    }
}