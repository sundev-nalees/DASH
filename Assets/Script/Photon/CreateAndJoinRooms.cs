using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    private string createInputText;
    private string joinInputText;


    public void ReadCreateInput(string input)
    {
        createInputText = input;
    }
    
    public void ReadJoinInput(string input)
    {
        joinInputText = input;
    }
    public void CreateRoom()
    {
       
        PhotonNetwork.CreateRoom(createInputText);

    }

    public void JoinRoom()
    {
        
        PhotonNetwork.JoinRoom(joinInputText);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

}
