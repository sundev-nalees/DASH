using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float minX; 
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    [SerializeField] float y;

    private void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);   
    }
}
