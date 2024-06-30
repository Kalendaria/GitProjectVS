using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2* 60f;
    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
        Debug.Log("GameManager instance set");
    }
    void Update()
    {
        gameTime += Time.deltaTime;
        if(gameTime > maxGameTime){
            gameTime = maxGameTime;
        }

    }
}
