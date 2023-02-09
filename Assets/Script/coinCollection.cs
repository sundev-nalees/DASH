using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class coinCollection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControl>())
        {
            PhotonView photonView = gameObject.GetComponent<PhotonView>();

            if (!photonView.IsMine)
            {
                photonView.TransferOwnership(other.GetComponent<PhotonView>().Owner);
            }
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
