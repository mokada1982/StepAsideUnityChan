using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
  //carPrefabを入れる
  public GameObject carPrefab;
  //coinPrefabを入れる
  public GameObject coinPrefab;
  //cornPrefabを入れる
  public GameObject conePrefab;
  //スタート地点
  private int startPos = 80;
  //ゴール地点
  private int goalPos = 360;
  //アイテムを出すx方向の範囲
  private float posRange = 3.4f;
  //--------------------
  //追加
  //--------------------
  //Unityちゃんのオブジェクト
  private GameObject unitychan;
  //UnityちゃんのZ位置取得用
  private float unityPosZ;
  //アイテム生成距離
  private int disPos = 40;


  //----------------------------------------------------------------------
  // Start is called before the first frame update
  //----------------------------------------------------------------------
  void Start()
  {
    //Unityちゃんのオブジェクトを取得
    this.unitychan = GameObject.Find("unitychan");
  }

  //----------------------------------------------------------------------
  // Update is called once per frame
  //----------------------------------------------------------------------
  void Update()
  {
    //UnityちゃんのZ位置を取得
    this.unityPosZ = this.unitychan.transform.position.z;
    //Unityちゃんの位置によりオブジェクトを生成
    if (this.unityPosZ > (startPos - disPos))
    {
      this.CreateItem();
    }
  }

  //----------------------------------------------------------------------
  //アイテム生成
  //----------------------------------------------------------------------
  void CreateItem()
  {
    //--------------------
    //一定の距離ごとにアイテムを生成
    //--------------------
    //for (int i = startPos; i < goalPos; i += 15)
    for (int i = startPos; i < (startPos + disPos); i += 15)
    {
      //どのアイテムを出すのかをランダムに生成
      int num = Random.Range(1, 11);
      if (num <= 2)
      {
        //コーンをx軸方向に一直線に生成
        for (float j = -1; j <= 1; j += 0.4f)
        {
          GameObject cone = Instantiate(conePrefab);
          cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
        }
      }
      else
      {
        //レーンごとにアイテムを生成
        for (int j = -1; j <= 1; j++)
        {
          //アイテムの種類を決める
          int item = Random.Range(1, 11);
          //アイテムを置くZ座標のオフセットをランダムに設定
          int offsetZ = Random.Range(-5, 6);
          //60%コイン配置、30%車配置、10%何もなし
          if (1 <= item && item <= 6)
          {
            //コインを生成
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
          }
          else if (7 <= item && item <= 9)
          {
            //車を生成
            GameObject car = Instantiate(carPrefab);
            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
          }
        }
      }
    }
    //--------------------
    //生成位置を変更
    //--------------------
    this.startPos += this.disPos;
  }
}
