using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviourPunCallbacks
{
    public static UIManager instance;
    
    [SerializeField] private int player1Score;
    [SerializeField] private int player2Score;

    [SerializeField] private TextMeshProUGUI player1;
    [SerializeField] private TextMeshProUGUI player2;

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
        if (photonView.IsMine)
        {
            UpdateScoreOnDisplay(player1Score,player2Score);
        }
        photonView.RPC("UpdateScoreOnDisplay", RpcTarget.Others, player1Score, player2Score);
    }
    [PunRPC]
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

    


}
