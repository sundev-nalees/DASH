using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviourPunCallbacks
{
    public static UIManager instance;
    
    [SerializeField] private int player1Score;
    [SerializeField] private int player2Score;

    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        /*if (photonView.IsMine)
        {
            UpdateScoreOnDisplay(player1Score,player2Score);
        }
        photonView.RPC("UpdateScoreOnDisplay", RpcTarget.Others, player1Score, player2Score);*/
    }

    

    

    [PunRPC]
    void UpdateScore(int playerId, int score)
    {
        if (playerId == 1)
        {
            player1Score = score;
            player1ScoreText.text = "Player 1: " + player1Score.ToString();
        }
        else if (playerId == 2)
        {
            player2Score = score;
            player2ScoreText.text = "Player 2: " + player2Score.ToString();
        }
    }

    public void IncreaseScore()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            player1Score++;
            photonView.RPC("UpdateScore", RpcTarget.Others, 1, player1Score);
            player1ScoreText.text = "Player 1: " + player1Score.ToString();
        }
        else if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            player2Score++;
            photonView.RPC("UpdateScore", RpcTarget.Others, 2, player2Score);
            player2ScoreText.text = "Player 2: " + player2Score.ToString();
        }
    }
    /* [PunRPC]
     private void UpdateScoreOnDisplay(int player1Score,int player2Score)
     {
         player1.text = "Player1: " + player1Score;
         player2.text = "Player2:" + player2Score;
     }
     public void UpdateScore(int player,int score)
     {
         if (player == 1)
         {
             player1Score += score;
         }
         if (player == 2)
         {

             player2Score += score;
         }
     }

     */


}
