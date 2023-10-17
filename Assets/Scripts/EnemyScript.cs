using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamage
{
    bool goingup;
    float spd = 0.02f;

    // Update is called once per frame
    void Update()
    {
        if(goingup)         //만약 현재가 올라가는 상태이면
            transform.Translate(Vector3.up * spd);     //위쪽으로 좌표를 계속 이동
        else                   //현재 올라가는 상태가 아니라면 (내려가는 상태)
            transform.Translate(Vector3.down * spd); //아래쪽으로 좌표를 계속 이동

    }

    public void GetDamage()
    {
        GameObject gago = GameObject.Find("Bar_Gago");     //몬스터와 충돌하면 플레이어 오브젝트 불러와서,
        gago.GetComponent<CharacterScript>().GoTo(new Vector3(gago.transform.position.x, -5f, gago.transform.position.z)); //플레이어를 바닥으로 떨어뜨림
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Bottom")      //아래 지점과 만나면
            goingup = true;                      //goingup을 true로 하여 위로 올라가고
        else if(collision.tag == "Ceil")    //위 지점과 만나면
            goingup = false;                   //goingup을 false로 하여 아래로 내려간다
    }
}
