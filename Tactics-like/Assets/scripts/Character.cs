using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int speed;
    public int move;
    public int maxHealth;
    public int currentHealth;
    public int maxMana;
    public int currentMana;
    public int attack_power;
    public int attack_range;
    public Item Head;
    public Item R_Hand;
    public Item Feet;
    public bool change_layer_up;
    public bool change_layer_down;

    //needs a climb up method
    //needs a move obstacle method


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = maxHealth + Head.health;
        attack_power = attack_power + R_Hand.attack;
        speed = speed + Feet.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (change_layer_up)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder += 1 ;
            change_layer_up = false;
        }
        if (change_layer_down)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder -= 1;
            change_layer_down = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("moveupleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            change_layer_up = true;
        }
        if (other.gameObject.CompareTag("moveupright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            change_layer_up = true;
        }
        if (other.gameObject.CompareTag("moveupdleft") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            change_layer_up = true;
        }
        if (other.gameObject.CompareTag("moveupdright") && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            change_layer_up = true;
        }
        

    }
        private void OnTriggerExit2D(Collider2D other)
        {

        if (other.gameObject.CompareTag("movedown")  && this.gameObject.GetComponent<SpriteRenderer>().sortingOrder == other.gameObject.GetComponent<SpriteRenderer>().sortingOrder)
        {
            change_layer_down = true;
        }
           
        }
}
