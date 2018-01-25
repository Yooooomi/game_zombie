using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_network : Photon.MonoBehaviour {

    private Vector3 real_position;
    private Quaternion real_rotation;

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(real_position);
            stream.SendNext(real_rotation);
        }
        else
        {
            real_position = (Vector3)stream.ReceiveNext();
            real_rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
