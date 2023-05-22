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
    private int localPlayerId;
    private int otherPlayerId;

    private int score = 1;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            // Get the local player's ID
            localPlayerId = PhotonNetwork.LocalPlayer.ActorNumber;

            // Get the other player's ID
            otherPlayerId = PhotonNetwork.LocalPlayer.GetNext().ActorNumber;

            // Send a value from the local player to the other player
            //photonView.RPC("SendValue", RpcTarget.Others, localPlayerId, otherPlayerId, 42);
            Debug.Log("local player Id" + localPlayerId);
            Debug.Log("otherplayer Id" + otherPlayerId);

        }
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
            UIManager.instance.IncreaseScore();
           
        }
        
    }
}
