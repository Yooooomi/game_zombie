using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class network_manager : Photon.MonoBehaviour
{
    data_center dc;
    public GameObject cam;
    private Vector3 real_position;
    private Quaternion real_rotation;
    public float to_place_speed = 1f;

    public List<GameObject> GO_proper_to_player = new List<GameObject>();
    public List<MonoBehaviour> Comp_proper_to_player = new List<MonoBehaviour>();

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            real_position = (Vector3) stream.ReceiveNext();
            real_rotation = (Quaternion) stream.ReceiveNext();
        }
    }

    void Start()
    {
        cam.transform.SetParent(null);
        dc = GetComponent<data_center>();
        dc.db.photonView.RPC("refresh_players", PhotonTargets.All);
        if (!photonView.isMine)
        {
            foreach (var i in GO_proper_to_player)
            {
                i.SetActive(false);
            }
            foreach (var i in Comp_proper_to_player)
            {
                i.enabled = false;
            }
        }
    }

    void Update()
    {
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, real_position, to_place_speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, real_rotation, to_place_speed * Time.deltaTime);
        }
    }
}
