using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Rigidbody2D rigid;
    Collider2D GroundCollid;
    Vector3 StartPos;
    GameObject gm;



    float spdLimit;    //점프, 이동할 수 있는 최댓값
    public double speed;        //점프, 이동할 속도(정도)
    static public bool IsGround;   //현재 캐릭터가 땅에 접촉했는지 체크하기



    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;       //시작 위치를 저장해서, 죽었을 때 돌아올 수 있도록 하기
        rigid = gameObject.GetComponent<Rigidbody2D>();   //이동을 위해 rigidbody  불러옴
        GroundCollid = gameObject.transform.Find("IsGround").gameObject.GetComponent<Collider2D>();  //충돌을 위해 collider 불러옴
        spdLimit = 6;                                   //버튼을 아무리 꾹 눌러도 spdLimit 이상으로는 speed가 올라가지 않음 (현재 한도 = 6)
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
        if (IsGround == true)                         //현재 캐릭터가 땅에 닿아 있을 때에만 아래 코드를 실행  -> isGround는 GroundChecker에서 변경
        {
            if (Input.GetAxisRaw("Horizontal") != 0)      //좌, 우 방향키를 누르면
            {
                if (speed < spdLimit)                                //한도까지 스피드를 계속해서 0.1씩 증가시킨다
                    speed += 0.1f;

                switch (Input.GetAxisRaw("Horizontal"))  //만약에 좌, 우 방향키를 눌렀을 때
                {
                    case 1:                                                  //이 키가 우측 방향키라면 sprite가 오른쪽을 보게 한다
                        transform.localScale = new Vector3(-2, transform.localScale.y, transform.localScale.z);
                        break;
                    case -1:                                                 //이 키가 좌측 방향키라면 sprite가 왼쪽을 보게 한다
                        transform.localScale = new Vector3(2, transform.localScale.y, transform.localScale.z);
                        break;
                    default:
                        break;
                }
            }

            if (Input.GetButtonUp("Horizontal"))       //좌, 우 방향키를 뗐을 때만 아래 코드를 실행한다 (점프 코드)
            {
                IsGround = false;                                            //점프 했으니 IsGround를 false로 바꾸어 더블 점프를 불가하게 한다

                rigid.AddForce(Vector3.up * (float)speed * 60);       //좌, 우 방향키 둘 중 하나를 누르면 위쪽으로 점프한다

                if (Input.GetKeyUp(KeyCode.RightArrow))     //우측 방향키를 누르면 speed*35만큼 우측으로 이동
                {
                    rigid.AddForce(Vector3.right * (float)speed * 35);
                }
                else if (Input.GetKeyUp(KeyCode.LeftArrow))  //좌측 방향키를 누르면 speed*35만큼 좌측으로 이동
                    rigid.AddForce(Vector3.left * (float)speed * 35);

                speed = 0;                                                         //speed를 0으로 다시 초기화시켜서, 키 다운 시 0부터 증가하도록 한다
            }
        }
    }

    public void DieCheck()   //<캐릭터가 죽었는지(떨어졌는지) 체크하는 함수
    {
        if(Mathf.Round(gameObject.transform.position.y) < -6) //캐릭터가 떨어졌다면
        {
            Debug.Log(GameManager.life);                                        
            if(GameManager.life > 0)                                                            //남은 라이프가 있으면
            {
                GoTo("StartPos");    //처음 위치으로 돌아간 후
                GameManager.life--;                                                                //라이프 1 감소시키기
            }
            else
            {
                gm.GetComponent<GameManager>().EndGame(); //라이프 0이면 게임 끝내기
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IScore  i_score = collision.gameObject.GetComponent<IScore>();   //충돌 물체에서 IScore 컴포넌트를 받아오는데
        if (i_score != null)                                                                                //만약 IScore 컴포넌트가 있으면(Ground라면)
        {
            i_score.GetScore();                                                                         //GetScore()함수를 사용해라
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ILucky i_lucky = collision.gameObject.GetComponent<ILucky>();    //충돌 물체에서 ILucky 컴포는트를 받아오되

        if (i_lucky != null)                                                                                  //만약 ILucky 컴포넌트가 있으면 (LuckyTree라면)
        {
            i_lucky.GetLuck();                                                                            //GetLuck함수를 사용하고
            Destroy(collision.gameObject);                                                     //충돌한 오브젝트를 없애라
        }

        IDamage i_damage = collision.gameObject.GetComponent<IDamage>();

        if(i_damage != null)
        {
            i_damage.GetDamage();
        }
    }

    public void GoTo(string str)
    {
        if(str == "StartPos")                                                  //만약 매개변수가 "StartPos"라면
            gameObject.transform.position = StartPos;      //시작 위치로 캐릭터 이동
    }

    public void GoTo(Vector3 vec)                                  //만약 매개변수가 좌표라면
    {
        gameObject.transform.position = vec;                //좌표 위치로 캐릭터 이동
    }
}
