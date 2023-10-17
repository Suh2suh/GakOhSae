using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Rigidbody2D rigid;
    Collider2D GroundCollid;
    Vector3 StartPos;
    GameObject gm;



    float spdLimit;    //����, �̵��� �� �ִ� �ִ�
    public double speed;        //����, �̵��� �ӵ�(����)
    static public bool IsGround;   //���� ĳ���Ͱ� ���� �����ߴ��� üũ�ϱ�



    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;       //���� ��ġ�� �����ؼ�, �׾��� �� ���ƿ� �� �ֵ��� �ϱ�
        rigid = gameObject.GetComponent<Rigidbody2D>();   //�̵��� ���� rigidbody  �ҷ���
        GroundCollid = gameObject.transform.Find("IsGround").gameObject.GetComponent<Collider2D>();  //�浹�� ���� collider �ҷ���
        spdLimit = 6;                                   //��ư�� �ƹ��� �� ������ spdLimit �̻����δ� speed�� �ö��� ���� (���� �ѵ� = 6)
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        MoveChar();
        DieCheck();
    }

    void MoveChar()
    {
        if (IsGround == true)                         //���� ĳ���Ͱ� ���� ��� ���� ������ �Ʒ� �ڵ带 ����  -> isGround�� GroundChecker���� ����
        {
            if (Input.GetAxisRaw("Horizontal") != 0)      //��, �� ����Ű�� ������
            {
                if (speed < spdLimit)                                //�ѵ����� ���ǵ带 ����ؼ� 0.1�� ������Ų��
                    speed += 0.1f;

                switch (Input.GetAxisRaw("Horizontal"))  //���࿡ ��, �� ����Ű�� ������ ��
                {
                    case 1:                                                  //�� Ű�� ���� ����Ű��� sprite�� �������� ���� �Ѵ�
                        transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
                        break;
                    case -1:                                                 //�� Ű�� ���� ����Ű��� sprite�� ������ ���� �Ѵ�
                        transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
                        break;
                    default:
                        break;
                }
            }

            if (Input.GetButtonUp("Horizontal"))       //��, �� ����Ű�� ���� ���� �Ʒ� �ڵ带 �����Ѵ� (���� �ڵ�)
            {
                IsGround = false;                                            //���� ������ IsGround�� false�� �ٲپ� ���� ������ �Ұ��ϰ� �Ѵ�

                rigid.AddForce(Vector3.up * (float)speed * 60);       //��, �� ����Ű �� �� �ϳ��� ������ �������� �����Ѵ�

                if (Input.GetKeyUp(KeyCode.RightArrow))     //���� ����Ű�� ������ speed*35��ŭ �������� �̵�
                {
                    rigid.AddForce(Vector3.right * (float)speed * 35);
                }
                else if (Input.GetKeyUp(KeyCode.LeftArrow))  //���� ����Ű�� ������ speed*35��ŭ �������� �̵�
                    rigid.AddForce(Vector3.left * (float)speed * 35);

                speed = 0;                                                         //speed�� 0���� �ٽ� �ʱ�ȭ���Ѽ�, Ű �ٿ� �� 0���� �����ϵ��� �Ѵ�
            }
        }
    }

    public void DieCheck()   //<ĳ���Ͱ� �׾�����(����������) üũ�ϴ� �Լ�
    {
        if(Mathf.Round(gameObject.transform.position.y) < -6) //ĳ���Ͱ� �������ٸ�
        {
            Debug.Log(GameManager.life);                                        
            if(GameManager.life > 0)                                                            //���� �������� ������
            {
                GoTo("StartPos");    //ó�� ��ġ���� ���ư� ��
                GameManager.life--;                                                                //������ 1 ���ҽ�Ű��
            }
            else
            {
                gm.GetComponent<GameManager>().EndGame(); //������ 0�̸� ���� ������
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IScore  i_score = collision.gameObject.GetComponent<IScore>();   //�浹 ��ü���� IScore ������Ʈ�� �޾ƿ��µ�
        if (i_score != null)                                                                                //���� IScore ������Ʈ�� ������(Ground���)
        {
            i_score.GetScore();                                                                         //GetScore()�Լ��� ����ض�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ILucky i_lucky = collision.gameObject.GetComponent<ILucky>();    //�浹 ��ü���� ILucky ������Ʈ�� �޾ƿ���

        if (i_lucky != null)                                                                                  //���� ILucky ������Ʈ�� ������ (LuckyTree���)
        {
            i_lucky.GetLuck();                                                                            //GetLuck�Լ��� ����ϰ�
            Destroy(collision.gameObject);                                                     //�浹�� ������Ʈ�� ���ֶ�
        }

        IDamage i_damage = collision.gameObject.GetComponent<IDamage>();

        if(i_damage != null)
        {
            i_damage.GetDamage();
        }
    }

    public void GoTo(string str)
    {
        if(str == "StartPos")                                                  //���� �Ű������� "StartPos"���
            gameObject.transform.position = StartPos;      //���� ��ġ�� ĳ���� �̵�
    }

    public void GoTo(Vector3 vec)                                  //���� �Ű������� ��ǥ���
    {
        gameObject.transform.position = vec;                //��ǥ ��ġ�� ĳ���� �̵�
    }
}
