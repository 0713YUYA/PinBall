using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	   //HingeJointコンポーネントを入れる
	   private HingeJoint myHingeJoint;

	   //初期の傾き
	   private float defaultAngle = 20;
	   //弾いた時の傾き
	   private  float flickAngle = -20; 
	   //画面サイズの取得（発展課題）
	   int Width = Screen.width;
	   int heigth = Screen.height;

	// Use this for initialization
	void Start () {
		    //HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);	
		}

		//矢印キー離された時フリッパーを戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
		//マルチタップ（発展課題）マウスの左クリックを押した時及びスマートフォンでタップした時、フリッパーを動かす
		if (Input.GetMouseButton (0)) {
			SetAngle (this.flickAngle);
		}
		//マルチタップ（発展課題）マウスの左クリックを離した時及びスマートフォンでタップを外した時に、フリッパーを元に戻す
		if (Input.GetMouseButtonUp (0)) {
			SetAngle (this.defaultAngle);
		}

		//マルチタップ（発展課題）
		if (Input.touchCount > 0) {

			//touchCountが0の時に呼ばれるエラーが出ます
			//このフレームでのタッチ情報を取得
			Touch[] myTouches = Input.touches;

			for (int i = 0; i < Input.touchCount; i++) {
				//タッチすると行う何かをここに記入
				 
				Debug.Log (myTouches [i].position);
			}
		}

	}
		
	//フリッパーの傾きを設定
	public void SetAngle (float angle) {
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;

	}
}
