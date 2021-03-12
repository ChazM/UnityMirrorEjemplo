using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server have started");
        //base.OnStartServer();
    }

    public override void OnStopServer()
    {
        Debug.Log("Server have stopped");
        base.OnStopServer();
    }

    /// <summary>
    /// Called on the client when connected to a server.
    /// <para>The default implementation of this function sets the client as ready and adds a player. Override the function to dictate what happens when the client connects.</para>
    /// </summary>
    /// <param name="conn">Connection to the server.</param>
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Evento: Cliente nuevo conectado");
        base.OnClientConnect(conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Evento: Cliente desconectado");
        base.OnClientDisconnect(conn);
    }

}
