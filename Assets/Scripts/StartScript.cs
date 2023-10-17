using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))        //스페이스를 누르면
        {
            SceneManager.LoadScene("Stage1");    //메인 게임 시작
        }
    }
}
