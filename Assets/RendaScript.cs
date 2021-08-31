using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RendaScript : MonoBehaviour
{
    public Text GoalNumTxt;
    public Text ResultTxt;
    public int PlayerCount;
    int GoalCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renda();
        ShowResult();
        Invoke("SceneManagerMethod", 5);    //5秒後にシーンが遷移

    }

    void Renda()    //経過した日にちによってゴール目標の点数を変える
    {
        int Day = GachaScript.day;
        if(Day == 2 || Day == 5 || Day == 8)
        {
            if(Day == 2)
            {
                GoalCount = 10;
                GoalNumTxt.text = GoalCount.ToString() + "回連打して敵を追い払え！";
            }

            if (Day == 5)
            {
                GoalCount = 15;
                GoalNumTxt.text = GoalCount.ToString() + "回連打して敵を追い払え！";
            }

            if (Day == 8)
            {
                GoalCount = 20;
                GoalNumTxt.text = GoalCount.ToString() + "回連打して敵を追い払え！";
            }
        }
    }

    void SceneManagerMethod() //連打回数がゴール目標より高いかどうかでシーン遷移を変える
    {
        if(PlayerCount > GoalCount)
            SceneManager.LoadScene("GachaScene");
        else
            SceneManager.LoadScene("GameOverScene");
    }

    void ShowResult()   //連打ゲームの結果を表示する関数
    {
        if (PlayerCount > GoalCount)

            ResultTxt.text = ("敵を追い払った！");
        else
            ResultTxt.text = ("負けた");
    }
}
