using System;
using Unity.Netcode;
using UnityEngine;

public class ClientPlayerMovement : NetworkBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        DisableComponents();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        enabled = IsClient;
        if (!IsOwner)
        {
            DisableComponents();
            enabled = false;
            return;
        }
        EnableComponents();
    }

    private void DisableComponents()
    {
        _playerMovement.enabled = false;
    }
    
    private void EnableComponents()
    {
        _playerMovement.enabled = true;
    }
}
