using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
		
	//小さい星の得点（課題）
	private int SmallStar = 10;
	//大きい星の得点（課題）
	private int LargeStar = 20;
	//小さい雲の得点（課題）
	private int SmallCloud = 30;
	//大きい雲の得点（課題）
	private int LargeCloud = 40;
	//ゲーム終了の判定（課題）
	private bool isEnd = false;
	//スコアを表示するテキスト（課題）
	private GameObject scoreText;
	//得点（課題）
	private int score;

	// Use this for initialization
	void Start () {


		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		//シーン中のscoreTestオブジェクトを取得（課題）
		this.scoreText = GameObject.Find("GameScoreText");
		if (this.scoreText == null) {
			Debug.Log ("GameScoreTextはnullだよ");

		}else{
			
			Debug.Log("GamescoreTextにオブジェクトが格納できているよ");

				}			
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";

		}
	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other) {
		
		if (other.gameObject.tag == "SmallStarTag") {
			//スコアを加算（課題）
			this.score += 10; 

		} else if (other.gameObject.tag == "LargeStarTag") {
			this.score += 20;

		} else if (other.gameObject.tag == "SmallCloudTag") {
			this.score += 30;

		} else if (other.gameObject.tag == "LargeCloudTag") {
			this.score += 40;

		} else {
			this.score += 0;
			Debug.Log (other.gameObject.tag);
		  }
			//ScoreText獲得した点数を表示（課題）
			this.scoreText.GetComponent<Text> ().text = "score" + this.score + "pt";

		  }
        }
