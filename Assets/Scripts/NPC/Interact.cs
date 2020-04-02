using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact
[AddComponentMenu("Intro PRG/RPG/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Variables
    [Header("Player and Camera connection")]
    //create two gameobject variables one called player and the other mainCam
    public GameObject mainCam;
    public GameObject player;
    #endregion
    #region Start
    public void Start()
    {
        //connect our player to the player variable via tag
        
        //connect our Camera to the mainCam variable via tag
    }

    #endregion
    #region Update   
    private void Update()
    {
        //if our interact key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            //create a ray
            Ray interact;
            //this ray is shooting out from the main cameras screen point center of screen
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            //create hit info
            RaycastHit hitInfo;
            //if this physics raycast hits something within 10 units
            if(Physics.Raycast(interact,out hitInfo, 10))
            {
                #region NPC tag
                //and that hits info is tagged NPC
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    //Debug that we hit a NPC 
                    Debug.Log("Talk to NPC");
                    if (hitInfo.collider.GetComponent<Dialogue>())
                    {
                        hitInfo.collider.GetComponent<Dialogue>().showDlg = true;
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                       // Camera.main.GetComponent<player.MouseLook>().enabled = false;
                        //GetComponent<player.MouseLook>
                    }
                }


                #endregion
                #region Item
                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    Debug.Log("Pick up item");
                }
                //Debug that we hit an Item
                #endregion
            }

        }

        
    }
    #endregion
}






