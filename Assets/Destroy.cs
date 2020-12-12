using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  //----------------------------------------------------------------------
  //宣言
  //----------------------------------------------------------------------
  //カメラオブジェクト
  private GameObject mainCamera;
  //カメラのZ位置取得用
  private float cameraPosZ;

  //----------------------------------------------------------------------
  // Start is called before the first frame update
  //----------------------------------------------------------------------
  void Start()
    {
    //カメラオブジェクトを取得
    this.mainCamera = GameObject.Find("Main Camera");
  }

  //----------------------------------------------------------------------
  // Update is called once per frame
  //----------------------------------------------------------------------
  void Update()
    {
    //カエラオブジェクトのZ位置を取得
    this.cameraPosZ = this.mainCamera.transform.position.z;
    //UnityちゃんのZ位置より前のオブジェクトを削除
    if (transform.position.z < this.cameraPosZ)
    {
      Destroy(gameObject);
    }
  }
}
