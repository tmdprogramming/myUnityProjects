using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
   
    public bool menu_yes;
    public bool menu_no;
    public bool menu_move;
    public bool menu_attack;
    public bool menu_wait;

    

    public int top_boundary;
    public int bottom_boundary;
    public int move;

    public GameObject menu_selector;
    
    public GameObject tile_manager;
    public GameObject action_menu;

    float laserLength = 200f;
    public RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            hit = Physics2D.Raycast(menu_selector.transform.position, Vector2.left, laserLength);
            
            if (hit.collider != null)
            {
                //Hit something, print the tag of the object
                Debug.Log("Hitting: " + hit.collider.tag);
                if (hit.collider.tag == "menu_yes")
                {
                    menu_yes = true;

                }
                if (hit.collider.tag == "menu_no")
                {
                    menu_no = true;

                }
                if (hit.collider.tag == "menu_move")
                {
                    tile_manager.SetActive(true);
                    menu_move = true;

                }
                if (hit.collider.tag == "menu_attack")
                {
                    tile_manager.SetActive(true);
                    menu_attack = true;

                }
                if (hit.collider.tag == "menu_wait")
                {
                    menu_wait = true;

                }

            }
            Debug.DrawRay(transform.position, Vector2.left * laserLength, Color.red);
        }



        if (Input.GetKeyDown(KeyCode.W) && menu_selector.transform.position.y < top_boundary) //move battle menu selector up
        {
            menu_selector.transform.position = new Vector2(menu_selector.transform.position.x, menu_selector.transform.position.y + move);
        }

        if (Input.GetKeyDown(KeyCode.S) && menu_selector.transform.position.y > bottom_boundary) // move battle menu selector down
        {
            menu_selector.transform.position = new Vector2(menu_selector.transform.position.x, menu_selector.transform.position.y - move);
        }
        


    }

}
