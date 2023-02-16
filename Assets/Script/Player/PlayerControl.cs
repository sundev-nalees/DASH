using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float playerSpeed;


    private float horizontal;
    private float vertical;
    private PhotonView view;
    private int playerId;
    private int score = 1;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            movementControl();
        }
        
    }

    private void movementControl()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 directions = new Vector3(horizontal, 0.0f, vertical) * playerSpeed * Time.deltaTime;
        transform.Translate(directions);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<coinCollection>() == true)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                UIManager.instance.UpdateScore(1,score);
            }
            else
            {
                UIManager.instance.UpdateScore(2, score);
            }
           /* ExitGames.Client.Photon.Hashtable playerProperties = PhotonNetwork.LocalPlayer.CustomProperties;
            playerProperties["score"] = (int)playerProperties["score"] + 1;
            PhotonNetwork.SetPlayerCustomProperties(playerProperties);*/
        }
        
    }
}
