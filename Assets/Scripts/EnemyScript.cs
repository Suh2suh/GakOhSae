using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamage
{
    bool goingup;
    float spd = 0.02f;

    // Update is called once per frame
    void Update()
    {
        if(goingup)         //���� ���簡 �ö󰡴� �����̸�
            transform.Translate(Vector3.up * spd);     //�������� ��ǥ�� ��� �̵�
        else                   //���� �ö󰡴� ���°� �ƴ϶�� (�������� ����)
            transform.Translate(Vector3.down * spd); //�Ʒ������� ��ǥ�� ��� �̵�

    }

    public void GetDamage()
    {
        GameObject gago = GameObject.Find("Bar_Gago");     //���Ϳ� �浹�ϸ� �÷��̾� ������Ʈ �ҷ��ͼ�,
        gago.GetComponent<CharacterScript>().GoTo(new Vector3(gago.transform.position.x, -5f, gago.transform.position.z)); //�÷��̾ �ٴ����� ����߸�
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Bottom")      //�Ʒ� ������ ������
            goingup = true;                      //goingup�� true�� �Ͽ� ���� �ö󰡰�
        else if(collision.tag == "Ceil")    //�� ������ ������
            goingup = false;                   //goingup�� false�� �Ͽ� �Ʒ��� ��������
    }
}
