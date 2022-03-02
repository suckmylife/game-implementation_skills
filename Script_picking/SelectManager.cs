using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    private GameObject[] players;

    public delegate void SelectHandler();
    public static event SelectHandler Unselect;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, float.MaxValue))
            {
                if(hit.collider.tag == "Player")
                {
                    PlayerCtrlPick player = hit.collider.GetComponent<PlayerCtrlPick>();
                    //SendMessage("SetUnselect", SendMessageOptions.DontRequireReceiver);                    
                    /*
                    foreach(GameObject obj in players)
                    {                        
                        if(obj != player.gameObject)
                        {
                            obj.GetComponent<PlayerCtrlPick>().SetUnselect();
                        }
                        //obj.SendMessage("SetUnselect", SendMessageOptions.DontRequireReceiver);
                    }*/
                    Unselect();
                    player.SetSelect();
                }
            }
        }
    }
}
