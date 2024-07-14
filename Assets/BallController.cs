using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアの初期値
    private int Point = 0;

    //スコアを表示するテキスト
    private GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreオブジェクトを取得
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        
    }

    //衝突時に呼ばれ得る関数
    void OnCollisionEnter(Collision other)
    {

        //各オブジェクトにぶつかったら得点を追加する
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.Point += 50;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.Point += 1;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.Point += 100;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.Point += 200;
        }

        this.scoreText.GetComponent<Text>().text = "SCORE " + this.Point;
    }

}
