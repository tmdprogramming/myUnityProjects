using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Selector : MonoBehaviour
{
    public bool top = false;
    public bool bot = false;
    public bool left = false;
    public bool right = false;
    public bool actionable;

    public bool move_up_left = false;
    public bool move_up_right = false;
    public bool move_up_d_left = false;
    public bool move_up_d_right = false;
    public bool move_down_left = false;
    public bool move_down_right = false;
    public bool move_down_d_left = false;
    public bool move_down_d_right = false;

    

    
    public Character unit;
    public Character target;

    public Battle_Controller controller;
    
    // Start is called before the first frame update
    void Start()
    {
        unit = controller.goesNext;

    }

    // Update is called once per frame
    void Update()
    {

        unit = controller.goesNext;


        if (Input.GetKeyDown(KeyCode.W) && !top)//move selector up
        {
            if (move_up_left) //up layer
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y + .75f);
            }
            if (move_down_left) //down layer
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y - .25f);
            }
            if (!move_up_left && !move_down_left) //if neither up or down, normal move
            {
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y + .25f);
            }
        }





        if (Input.GetKeyDown(KeyCode.S) && !bot)//move selector down
        {
            if (move_up_d_right)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y + .25f);
            }
            if (move_down_d_right)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y - .75f);
            }
            if (!move_up_d_right && !move_down_d_right)
            {
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y - .25f);
            }
        }





        if (Input.GetKeyDown(KeyCode.A) && !left)//move selector left
        {
            if (move_up_d_left)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y + .25f);
            }
            if (move_down_d_left)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y - .75f);
            }
            if (!move_up_d_left && !move_down_d_right)
            {
                this.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y - .25f);
            }
        }




        if (Input.GetKeyDown(KeyCode.D) && !right)//move selector right
        {
            if (move_up_right)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1;
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y + .75f);
            }
            if (move_down_right)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y - .25f);
            }
            if (!move_up_right && !move_down_right)
            {
                this.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y + .25f);
            }
        }

        if(actionable)
        {
            controller.moveable_space = true;
        }
        if(!actionable)
        {
            controller.moveable_space = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("top"))
        {
            top = true;
        }
        if (other.gameObject.CompareTag("bot"))
        {
            bot = true;
        }
        if (other.gameObject.CompareTag("right"))
        {
            right = true;
        }
        if (other.gameObject.CompareTag("left"))
        {
            left = true;
        }
        if (other.gameObject.CompareTag("moveupleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_up_left = true;
        }
        if (other.gameObject.CompareTag("moveupright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_up_right = true;
        }
        if (other.gameObject.CompareTag("moveupdleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_up_d_left = true;
        }
        if (other.gameObject.CompareTag("moveupdright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_up_d_right = true;
        }
        if (other.gameObject.CompareTag("movedownleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_down_left = true;
        }
        if (other.gameObject.CompareTag("movedownright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_down_right = true;
        }
        if (other.gameObject.CompareTag("movedowndleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_down_d_left = true;
        }
        if (other.gameObject.CompareTag("movedowndright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            move_down_d_right = true;
        }


        if (other.gameObject.GetComponent<Character>())
        {
            target = other.gameObject.GetComponent<Character>();
        }
        if (other.gameObject.GetComponent<action_tile>())
        {
            actionable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("top"))
        {
            top = false;
        }
        if (other.gameObject.CompareTag("bot"))
        {
            bot = false;
        }
        if (other.gameObject.CompareTag("right"))
        {
            right = false;
        }
        if (other.gameObject.CompareTag("left"))
        {
            left = false;
        }
        if (other.gameObject.CompareTag("moveupleft")) //do not need to compare sorting level when leaving the trigger
        {
            move_up_left = false;
        }
        if (other.gameObject.CompareTag("moveupright"))
        {
            move_up_right = false;
        }
        if (other.gameObject.CompareTag("moveupdleft"))
        {
            move_up_d_left = false;
        }
        if (other.gameObject.CompareTag("moveupdright"))
        {
            move_up_d_right = false;
        }
        if (other.gameObject.CompareTag("movedownleft"))
        {
            move_down_left = false;
        }
        if (other.gameObject.CompareTag("movedownright"))
        {
            move_down_right = false;
        }
        if (other.gameObject.CompareTag("movedowndleft"))
        {
            move_down_d_left = false;
        }
        if (other.gameObject.CompareTag("movedowndright"))
        {
            move_down_d_right = false;
        }
        if (other.gameObject.GetComponent<action_tile>())
        {
            actionable = false;
        }
        if (other.gameObject.GetComponent<Character>())
        {
            target = null;
        }
    }
 
  

}
 

