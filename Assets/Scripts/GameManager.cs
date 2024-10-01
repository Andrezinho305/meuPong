using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player; //referencia de transform/posição na cena
    public Transform enemy;
    public BallControl ballControl;

    [Header("Points")]
    public int playerScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public int winPoints = 5;

    [Header("End Screen")]
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;



    void Start() //quando o jogo inicia, ele reseta
    {
        ResetGame();
    }

    public void ResetGame()
    {
        player.position = new Vector3(-6f, 0f, 0f); //pq usar Vector2 ou Vector3?
                                                //Vector2 armazena em X e Y apenas, Vector3 permite armazenar informações sobre Z também
        enemy.position = new Vector3(6f, 0f, 0f);

        ballControl.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);

    }


    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();//pega o valor do score e transforma no texto
        WinCondition();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        WinCondition();
    }

    public void WinCondition()
    {
        if(enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f); //chamada em delay - atrasa o método chamado em X segundos
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
