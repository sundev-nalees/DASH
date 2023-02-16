using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class coinCollection : MonoBehaviourPunCallbacks
{
    

    
    [SerializeField] private int point;
    
    [PunRPC]
    void DestroyCoin()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        photonView.RPC("DestroyCoin", RpcTarget.MasterClient);
    }
   
}
