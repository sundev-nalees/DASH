using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float numberOfCoins;
    [SerializeField] private float fieldLength=430f;
    [SerializeField] private float fieldBreadth=220f;

    void Start()
    {
        SpawnCoin();
    }

    
    private void SpawnCoin()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                float x = Random.Range(-fieldLength / 2, fieldLength / 2);
                float z = Random.Range(-fieldBreadth / 2, fieldBreadth / 2);
                Vector3 spawnPosition = new Vector3(x, 13, z);
                PhotonNetwork.Instantiate(coinPrefab.name, spawnPosition, Quaternion.identity);
            }
        }
        
    }
}
