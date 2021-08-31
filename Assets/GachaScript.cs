using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GachaScript : MonoBehaviour
{
    public GameObject[] character = new GameObject[3];  //成長前のキャラクターを格納する配列
    public GameObject[] seichou = new GameObject[3];    //成長したキャラクターを格納する配列
    public Button DrawGacha;    //ガチャを引くボタン
    public Button DayPass;      //日付を進めるボタン（本当は実際の時間経過で行う）
    public Text DayTxt;         //日付表示用テキスト
    public Text SeichouTxt;     //成長した！と表示するテキスト
    static int flag = 0;        //ガチャを引くボタンを判定するflag変数 ※staticにすると中身の値を保持したまま他のスクリプトから参照出来る
    public static int day = 1;  //日付カウント変数 ※staticにすると中身の値を保持したまま他のスクリプトから参照出来る
    static int RandomNum = 0;          //乱数代入用変数

    // Start is called before the first frame update
    void Start()
    {
        DayTxt.text = day.ToString() + "日目";
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1)
        {
            NonGachaButton();
            character[RandomNum].SetActive(true);
            if (day == 10)
            {
                character[RandomNum].SetActive(false);  //成長前のキャラクターを見えなくする
                seichou[RandomNum].SetActive(true);     //成長後のキャラクターを見えるようにする
                SeichouTxt.gameObject.SetActive(true);
                //Debug.Log("成長した！");
                DayPass.gameObject.SetActive(false);    //成長後は日付を進める必要がないので日付を進めるボタンを見えなくする
            }
        }
    }

    public void GachaResult()　//ガチャの結果を出力する関数
    {
        RandomNum = Random.Range(0, 3); //0～2の範囲で乱数出力
        character[RandomNum].SetActive(true);   //RandomNumに代入された数字に対応する番号のゲームオブジェクト配列のデータを見えるようにする
        Debug.Log("ガチャの番号"+RandomNum);
        flag = 1;   //flag変数を1にする(＝ガチャが引かれた事を示す）
        //NonGachaButton();
    }

    public void NonGachaButton()    //ガチャを引き終わったら"ガチャを引くボタン"を見えなくする
    {
        DrawGacha.gameObject.SetActive(false);
    }

    public void PassDay()   //日数の経過をボタンを押す事で簡易的に表現した関数
    {
        if(flag == 1)   //flagが1つまりガチャが引かれた場合は以下の処理をする
        {
            day++;
            Debug.Log(day + "日目");
            DayTxt.text = day.ToString() + "日目";
            if (day == 2 || day == 5 || day == 8)
            {
                SceneManager.LoadScene("RendaScene");
            }
        }
    }
}
