using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameController : MonoBehaviour
{
    public int totalScore=0;
    public Text scoreText;
    public static gameController Instance;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; //给静态方法初始化
    }

    public void UpdateScore()
    {
        this.scoreText.text = totalScore.ToString();
        //Debug.Log(totalScore+"21513");
    }

    public void showGameoverPanel()
    {
        gameoverPanel.SetActive(true);
    }
    // Update is called once per frame

    public void restart(string name)
    {
        SceneManager.LoadScene(name);

    }
    void Update()
    {
        
    }
}
