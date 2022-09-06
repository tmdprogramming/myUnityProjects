using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Controller : MonoBehaviour
{
    public bool new_turn;
    public bool moved;
    public bool moveable_space;
    public bool attackable_space;
    public bool attacked;
    public Character[] characters;
    public int length;
    public int xspeed = 0;
    public Character goesNext;
    public Camera main_camera;

    public GameObject battle_menu_canvas;
    public GameObject action_canvas;
    public GameObject move_selector;

    public Menu_Manager menu;
    public Enemy_AI_Manager enemy;

    public float seconds;
    public float timer;
    public float speed;
    public Vector2 end;
    public Vector2 Difference;
    public Vector2 start;

    
    // Start is called before the first frame update
    void Start()
    {
        new_turn = true;
    }
    private void OnEnable()
    {
        new_turn = true;
        xspeed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (new_turn)
        {
            xspeed = 0;
            for (int x = 0; x < length; x++)
            {
                characters[x].speed++;

            }
        
            moved = false;
            attacked = false;
            
            length = characters.Length;

            for (int x = 0; x < length; x++)
            {
                if (xspeed < characters[x].speed)
                {
                    xspeed = characters[x].speed;
                    goesNext = characters[x];
                }
            }
            if(goesNext.tag == "enemy")
            {
                Debug.Log("enemy turn");
                this.GetComponent<Enemy_AI_Manager>().enabled = true;
                this.GetComponent<Battle_Controller>().enabled = false;
                
            }
            if (goesNext.tag == "allies")
            {
                battle_menu_canvas.SetActive(true);
            }
                move_selector.transform.position = new Vector2(goesNext.transform.position.x, goesNext.transform.position.y +.4f);

            new_turn = false;
        }
        
        if (menu.menu_move)
        {

            
                move_selector.SetActive(true);
            
            battle_menu_canvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.B) && moveable_space)
        {
            move_selector.GetComponent<Move_Selector>().enabled = false;
            action_canvas.SetActive(true);
            moveable_space = false;
        }
        if (menu.menu_no && menu.menu_move)
        {
            move_selector.GetComponent<Move_Selector>().enabled = true;
            menu.menu_no = false;
            menu.menu_move = false;
            action_canvas.SetActive(false);
            battle_menu_canvas.SetActive(true);
            move_selector.SetActive(false);
        }
        if (menu.menu_yes && menu.menu_move)
        {
           
            //on player move change sorting order
            
            action_canvas.SetActive(false);
            if (timer <= seconds)
            {

                timer += Time.deltaTime;
                start = new Vector2(goesNext.transform.position.x, goesNext.transform.position.y);
                end = new Vector2(move_selector.transform.position.x, move_selector.transform.position.y -.4f);
                goesNext.transform.position = Vector2.MoveTowards(start,end,speed * Time.deltaTime);
                //goesNext.GetComponent<SpriteRenderer>().sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
                //if something is in way then move around it
            }
            if (timer > seconds || (goesNext.transform.position.x, goesNext.transform.position.y) == (move_selector.transform.position.x, move_selector.transform.position.y - .4f))
            {
                move_selector.GetComponent<Move_Selector>().enabled = true;
                menu.menu_yes = false;
                menu.menu_move = false;
                move_selector.SetActive(false);
                battle_menu_canvas.SetActive(true);
                timer = 0;
                moved = true;
            }
        }












        //move player to selector
        if (Input.GetKeyDown(KeyCode.B) && menu.menu_attack)
        {

            move_selector.SetActive(true);
            battle_menu_canvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.B) && attackable_space)
        {
            
            action_canvas.SetActive(true);
            move_selector.SetActive(false);
            attackable_space = false;
        }
        if (menu.menu_no && menu.menu_attack)
        {

            menu.menu_no = false;
            menu.menu_attack = false;
            action_canvas.SetActive(false);
            battle_menu_canvas.SetActive(true);
        }
        if (menu.menu_yes && menu.menu_attack)
        {
            move_selector.GetComponent<Move_Selector>().target.currentHealth = move_selector.GetComponent<Move_Selector>().target.currentHealth - goesNext.attack_power;
            menu.menu_yes = false;
            menu.menu_attack = false;
            action_canvas.SetActive(false);
            battle_menu_canvas.SetActive(true);
            attacked = true;

        }


        if (menu.menu_wait)
        {
            battle_menu_canvas.SetActive(false);
            action_canvas.SetActive(true);
            move_selector.SetActive(false);
        }

        if (menu.menu_wait && menu.menu_yes)
        {
            goesNext.speed = 0;
            menu.menu_wait = false;
            menu.menu_yes = false;
            action_canvas.SetActive(false);
            moved = false;
            attacked = false;
            new_turn = true;
           
        }


        //back to battle-menu
        if (Input.GetKeyDown(KeyCode.V)|| (menu.menu_wait && menu.menu_no)) //V is to cancel back to battle-menu
        {
            // set all tiles to false;
            move_selector.GetComponent<Move_Selector>().enabled = true;
            menu.menu_attack = false;
            menu.menu_move = false;
            menu.menu_wait = false;
            action_canvas.SetActive(false);
            move_selector.SetActive(false);
            battle_menu_canvas.SetActive(true);
        }
    }

}





    
