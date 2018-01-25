using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class network_debug : Photon.MonoBehaviour {

    void Start()
    {
        Connect();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }

    void OnCreatedRoom()
    {
        Debug.Log("CreatedRoom");
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("player_prefab", Vector3.zero, Quaternion.identity, 0);
        Debug.Log("OnJoinedRoom");
    }

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("1");
    }
}
