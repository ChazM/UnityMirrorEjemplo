using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Player : NetworkBehaviour
{
    [SerializeField]
        Vector3 PlayerPos;
    
    /// <summary>
    /// syncvar ejemplo 1
    /// </summary>
    [SyncVar(hook = nameof(onChangeReceived))]
    float moneyAccount =25.20f;

    /// <summary>
    /// syncvar ejemplo 2 monitorear el color de un jugador cuando cambie al conectarse al servidor
    /// </summary>
    [SyncVar(hook = nameof(SetColor))]
    Color playerColor = Color.black;


    void handleMovements(){
     if(isLocalPlayer){
         float Move_H = Input.GetAxis("Horizontal");
         float Move_V = Input.GetAxis("Vertical");

         Vector3 Movement =  new Vector3 (Move_H, 0, Move_V);         
         transform.position = transform.position + Movement;
         PlayerPos = transform.position;
     }
 }

 void Update (){
        handleMovements();
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("I want a soda from server");
            buySoda();
        }     
     
 }

    public override void OnStartServer()
    {
        Debug.Log("player has been spawned");
        playerColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        base.OnStartServer();
    }

    /// <summary>
    /// cuando el jugador compre una soda recibira un mensaje con la actualizacion de sus fondos 
    /// </summary>
    /// <param name="oldMoneyCount"></param>
    /// <param name="newMoneyCount"></param>
    void onChangeReceived(float oldMoneyCount, float newMoneyCount) {
        Debug.Log("we used to have " + oldMoneyCount);
        Debug.Log("Now we have " + newMoneyCount);
    }
    /// <summary>
    /// cuando el jugador se conecte al servidor recibira un color diferente
    /// </summary>
    /// <param name="oldColor"></param>
    /// <param name="newColor"></param>
    void SetColor(Color oldColor, Color newColor){
        GetComponent<MeshRenderer>().material.color = newColor;
    }






    #region Tipos de procedimientos remotos en mirror
    /// <summary>
    /// using commnd is a dirty way to get info or actions from server in this way
    /// Authority and security
    /// llemados por el cliente y ejecutados en el servidor
    /// </summary>
    [Command]
    void buySoda() {
        Debug.Log("player has  tried to bought a soda in server");
        if (moneyAccount < 2.5)
        {
            Debug.Log("can not buy more sodas :( in this server");
            Debug.Log("get the hell out!!!!");
            return;
        }
        else {
            moneyAccount = moneyAccount - 2.5f;
            GiveBackChangeToClient(moneyAccount);
        }

    }


    /// <summary>
    /// any server object can call a client RPC
    /// no se deben llamar desde Update ya que esto provocara spam por toda la red
    /// llamados por el servidor y corren en todos los clientes
    /// </summary>
    [ClientRpc]
    void retireMoney(){
        Debug.Log(" I want to retire money");
    }

    /// <summary>
    /// llamados por el servidor y ejecutados en clientes especificos.
    /// </summary>
    [TargetRpc]
    void GiveBackChangeToClient( float change ){
        Debug.Log("your change is $ "+ change); 
    }
    #endregion

}
