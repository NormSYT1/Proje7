using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    public TMP_Text coinText, lastText, highestText;
    private int totalCoin = 0;
    public GameObject panel;
    void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 5f) * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        coinText.text = "Total Coin: " + totalCoin.ToString();
        if (totalCoin > PlayerPrefs.GetInt("HighScore")) 
        {
            PlayerPrefs.SetInt("HighScore", totalCoin);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            totalCoin++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy") 
        {
            Time.timeScale = 0f;
            Destroy(other.gameObject);
            panel.SetActive(true);
            lastText.text = "Total Coin: " + totalCoin.ToString();
            highestText.text = "The Highest Score: " + PlayerPrefs.GetInt("HighScore").ToString();
            Cursor.visible = true;
        }
    }
}
