using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rd;
    public int score = 0;
    public Text scoreText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("游戏开始了");
        //打印一行语句
        //记录游戏日志

        rd = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("游戏正在运行");
        //rd.AddForce(Vector3.right);
        //rd.AddForce(new Vector3(0, 0, 1));

        float h = Input.GetAxis("Horizontal");//水平，按住A或D，h逐渐增加至-1或1
        float v = Input.GetAxis("Vertical");//垂直
        //Debug.Log(h);
        rd.AddForce(new Vector3(h, 0, v)*1.5f);

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("发生碰撞了");

    //    if (collision.gameObject.tag == "Food") 
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("碰撞结束了");
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("正在碰撞");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("进入触发区域");
        Debug.Log("OnTriggerEnter " + other.tag);
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;

            scoreText.text = "分数：" + score;

            if (score == 10)
            {
                winText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("离开触发区域");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("在触发区域中");
    }
}
