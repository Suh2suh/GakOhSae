using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTexter : MonoBehaviour
{
    GameObject playername;
    User u1;

    string g_name;

    Text uname;
    Text uscore;
    Text lastscore;

    void Start()
    {

        playername = GameObject.Find("Playername");

        uname = GameObject.Find("TxtName").GetComponent<Text>();
        uscore = GameObject.Find("TxtScore").GetComponent<Text>();
        lastscore = GameObject.Find("TxtLastScore").GetComponent<Text>();

        LoadResult();
    }

    public void GetName()
    {
        g_name = "";
        try
        {
            g_name = playername.GetComponent<Text>().text.Trim(); //플레이어가 입력한 이름 받아오고, 공백 지우기
            if (!(g_name is null))
            {
                u1.username = g_name;
                Debug.Log(u1.username);
            }
        }
        catch(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("LogErrors.txt", false))
            {
                sw.WriteLine(ex.Message);

                sw.Flush();
                sw.Close();
            }

            g_name = "noname";
        }
    }

    public void ShowResult()
    {
        uname.text = g_name;
        uscore.text = GameManager.score.ToString();

        SaveResult();
    }

    public void SaveResult()
    {
        using (StreamWriter sw = new StreamWriter("LastScore.txt", false))
        {
            sw.WriteLine(uscore.text);

            sw.Flush();
            sw.Close();
        }
    }

    public void LoadResult()
    {
        using (StreamReader sr = new StreamReader("LastScore.txt"))
        {
            lastscore.text = sr.ReadLine();

            sr.Close();
        }
    }
}

public struct User
{
    public string username;
    public long userscore;

    public User(string name, long score)
    {
        username = name;
        userscore = score;
    }
}