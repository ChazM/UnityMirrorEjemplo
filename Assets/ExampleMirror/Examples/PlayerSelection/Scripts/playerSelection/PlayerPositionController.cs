using UnityEngine;
using System.Collections;


public class PlayerPositionController : MonoBehaviour
{
    [Range(0, 5)]
    public int numberOfPlayers;

    [SerializeField]
    public GameObject[] players;

    [Range(0, 10)]
    public float xradius = 5;
    [Range(0, 10)]
    public float yradius = 5;    
    [SerializeField]
    GameObject centerPivot;
    [SerializeField]
    GameObject playerPos;
    public GameObject [] positions;
    void Start()
    {
        players = Resources.LoadAll<GameObject>("playerPrefabs");
        positions = new GameObject[players.Length];
        numberOfPlayers = positions.Length;
        instantiatePoints();
        CreatePoints();
    }


    Color playerColor = Color.black;

    #region Create Dynamic circle selector
    void instantiatePoints() {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            var pos = Instantiate(players[i], centerPivot.transform.position, Quaternion.identity);
            positions[i] = pos;           
            positions[i].transform.parent = centerPivot.transform;
            positions[i].transform.forward = new Vector3(0, 0, -1);
            //playerColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //positions[i].GetComponent<MeshRenderer>().material.color = playerColor;
        }        
    }
    void CreatePoints()
    {
        float x;
        float y;
        float z;

        float angle = 20f;

        for (int i = 0; i < numberOfPlayers; i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            setPositions(positions[i], new Vector3(x, 0, y));

            angle += (360f / numberOfPlayers);
        }
    }
    void setPositions(GameObject playerPositions,Vector3 position) {
        playerPositions.transform.position = position;
    }
    #endregion


}