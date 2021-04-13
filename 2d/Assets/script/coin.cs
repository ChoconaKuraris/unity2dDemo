using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D col;
    public bool eat =false;
    public int score = 100;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _spriteRenderer.enabled = false; //图片消失
            col.enabled = false;
            eat = true;
            gameController.Instance.totalScore += score; //实例化静态方法管理总分数
            gameController.Instance.UpdateScore();     
            Destroy(gameObject,1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
