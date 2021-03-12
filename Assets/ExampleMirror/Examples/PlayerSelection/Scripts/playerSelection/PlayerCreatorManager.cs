using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerCreatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] players; 
    [SerializeField]
     GameObject[] chars;
    [SerializeField]
    int selectedPlayer;
    [SerializeField]
    PlayerPositionController positionController;
  
    [SerializeField]
    GameObject playersParent;


    int prevChar, nextChar;


    // Start is called before the first frame update
    void Start()
    {
        instantiatePoolPlayer();
    }

    public void instantiatePoolPlayer() {
        players = Resources.LoadAll<GameObject>("playerPrefabs");
        chars = new GameObject[players.Length];
        for (int x = 0; x <players.Length; x++){
            chars[x]=Instantiate(players[x],positionController.positions[x].transform.position,Quaternion.identity);
            //chars[x] = Instantiate(players[x], notVisiblePosition.position, Quaternion.identity);
        }

        foreach (var item in chars)
        {
            item.transform.parent = playersParent.transform;
        }
    }
         



  
}
