using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Player : NetworkBehaviour
{
    [SerializeField]
        Vector3 PlayerPos;
   
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
 }

}
