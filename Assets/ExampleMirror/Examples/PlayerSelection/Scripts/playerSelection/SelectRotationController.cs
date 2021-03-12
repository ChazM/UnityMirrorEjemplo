using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRotationController : MonoBehaviour
{

    Vector3 targetRot;
    Vector3 currentAngle;
   
    [SerializeField]
    int currentSelection;
    [SerializeField]
    int totalCharacters;
    [SerializeField]
    int wheelAngleSplitValue=0;
    [SerializeField]
    Transform pivot;

    private void Start()
    {
        currentSelection = 1;
    }


    public void selectToRight() {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentSelection < totalCharacters-1){
            currentSelection++;
            Debug.Log("Right arrow pressed");
            currentAngle = pivot.eulerAngles;
            targetRot = new Vector3(0,currentAngle.y + wheelAngleSplitValue, 0);
                      
        }
         currentAngle.y = Mathf.MoveTowardsAngle(currentAngle.y, targetRot.y, 90 * Time.deltaTime);
        //currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y , 25f + Time.deltaTime), 0);
        pivot.eulerAngles = currentAngle;
    }

    public void selectToLeft() {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && currentSelection >= 1){
            Debug.Log("Left arrow pressed");
            currentAngle = pivot.eulerAngles;
            targetRot = new Vector3(0,currentAngle.y -wheelAngleSplitValue, 0);
            currentSelection--;
        }
        currentAngle.y = Mathf.MoveTowardsAngle(currentAngle.y, targetRot.y, 90 * Time.deltaTime);
        //currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y , 2.5f + Time.deltaTime), 0);
        pivot.eulerAngles = currentAngle;
    }

    public void selectToRightUI()
    {
        if (currentSelection <= totalCharacters)
        {
            Debug.Log("dale para la derecha");
            currentAngle = pivot.eulerAngles;
            targetRot = new Vector3(0, currentAngle.y + wheelAngleSplitValue, 0);
            currentSelection++;
        }
        currentAngle.y = Mathf.MoveTowardsAngle(currentAngle.y, targetRot.y, 90 * Time.deltaTime);
        //currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y , 25f + Time.deltaTime), 0);
        pivot.eulerAngles = currentAngle;
    }
    public void selectToLeftUI()
    {
        if (currentSelection >= 1)
        {
            Debug.Log("dale para la izquierda");
            currentAngle = pivot.eulerAngles;
            targetRot = new Vector3(0, currentAngle.y - wheelAngleSplitValue, 0);
            currentSelection--;
        }
        currentAngle.y = Mathf.MoveTowardsAngle(currentAngle.y, targetRot.y, 90 * Time.deltaTime);
        //currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y , 2.5f + Time.deltaTime), 0);
        pivot.eulerAngles = currentAngle;
    }
    // Update is called once per frame
    void Update()
    { 
        totalCharacters = transform.childCount;
        Debug.Log("child count is : " + totalCharacters);
        wheelAngleSplitValue = 360 / totalCharacters;
        #region select with keyboard
        selectToRight();
        selectToLeft();
        #endregion    
    }
}
