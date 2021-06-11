using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class PlayerInput : NetworkBehaviour
{
    //Components
    private NetworkPlayer player;

    public MyInput input = new MyInput();

    void Start()
    {
        player = GetComponent<NetworkPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.IsLocalPlayer) return;
        input.Input();
    }
}