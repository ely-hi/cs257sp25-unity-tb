using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField] Life playerLife;
    [SerializeField] Life playerBaseLife;

    void Awake()
    {
        // playerLife.onDeath.AddListener(OnPlayerDied);
        // playerBaseLife.onDeath.AddListener(OnPlayerDied);
        playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);
    }

    // void OnPlayerDied()
    // {
    //     SceneManager.LoadScene("LoseScreen");
    // }

    void OnPlayerOrBaseDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    // Update is called once per frame
    void CheckWinCondition()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 &&
             WavesManager.instance.waves.Count <= 0)
             {
                //SceneManager.LoadScene("You win!");
                SceneManager.LoadScene("WinScreenActual");
             }   

        // if (playerLife.amount <= 0) {
        //     //SceneManager.LoadScene("You lose!");
        //     SceneManager.LoadScene("LoseScreen");
        // }
    }
}
