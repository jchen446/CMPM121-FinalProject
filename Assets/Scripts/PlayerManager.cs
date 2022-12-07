using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int playerHP = 100;


    public bool isGameOver;
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene("Restart");
            Debug.Log("Defeat");
        }
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        Debug.Log(playerHP);
        if (playerHP <= 0){
            isGameOver = true;
        }
        yield return new WaitForSeconds(1);

    }
}
