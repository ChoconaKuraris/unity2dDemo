using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScore : MonoBehaviour
{
    //text预制体
    public GameObject TextType; //text预制体
    //生成text的引用对象
    private GameObject scoreText; //获取预制体
    private Text textUI;
    public coin coin;

    private int score = 100;
    private const float moveUpSpeed = 50;
    private bool hasCreateTextUI = false;

    private float max_height;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private  void createScoreUI(bool canCreate)
    {
        if (canCreate)
        {
            coin.eat = false;
            scoreText = Instantiate(TextType, GameObject.Find("Canvas").transform); //创建分数text，父节点为scoreCanvas
            textUI = scoreText.GetComponent<Text>();  //获取text预制体的text
            textUI.text = score.ToString();
            scoreText.transform.position = TextType.transform.position = Camera.main.WorldToScreenPoint(transform.position);//改变世界坐标为屏幕坐标
            max_height = scoreText.transform.position.y+20f;
            hasCreateTextUI = true;
        }
        
    }

    private void FixedUpdate()
    {
        createScoreUI(coin.eat);

         if (hasCreateTextUI)
         {
             if (scoreText.transform.position.y >= max_height)
             {
                 Destroy(scoreText);
                 hasCreateTextUI = false;
            }
             scoreText.transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;

         }



    }
}
    // Update is called once per frame
   

