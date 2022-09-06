using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Manager : MonoBehaviour
{
    public Battle_Controller controller;
    public Character enemy;
    public tile_manager tile;
    public GameObject[] moveTiles;
    public GameObject[] allyPlayers;
    public Character target;
    public int allyHealth;
    public Vector2 target_position;
    public Vector2 tile_position;
    public Vector2 end;
    public Vector2 start;
    public float difference;
    public float temp;
    public float timer;
    public float speed;
    public float seconds;
    public bool move;
    public bool begin;
    public bool endturn;
    public bool step1;
    public bool step2;
    public bool step3;
    public bool do_once;
    // Start is called before the first frame update
    void OnEnable()
    {
        endturn = false;
        begin = true;
        do_once = true;
        difference = 999;
        seconds = 500;
        allyHealth = 1000;
        enemy = controller.goesNext;


        // check for ally player with least health
        allyPlayers = GameObject.FindGameObjectsWithTag("allies");
        foreach (GameObject allyPlayer in allyPlayers)
        {
            if (allyHealth > allyPlayer.GetComponent<Character>().currentHealth)
            {
                allyHealth = allyPlayer.GetComponent<Character>().currentHealth;
                target = allyPlayer.GetComponent<Character>();

            }
            target_position = new Vector2(allyPlayer.GetComponent<Character>().transform.position.x, allyPlayer.GetComponent<Character>().transform.position.y);
        }





    }

    // Update is called once per frame
    void Update()
    {
        if (begin)
        {
            StartCoroutine(Wait());
            begin = false;
        }
        if(step1) //show move tiles
        {
            StartCoroutine(Wait2());
            if (do_once)
            {
                tile.gameObject.SetActive(true);
                tile.enemy_move = true;
                do_once = false;
            }

            moveTiles = GameObject.FindGameObjectsWithTag("movetile");
            foreach (GameObject moveTile in moveTiles)
            {
                tile_position = new Vector2(moveTile.transform.position.x, moveTile.transform.position.y);
                temp = Vector2.Distance(tile_position, target_position);
                if (temp < difference)
                {
                    difference = temp;
                    end = tile_position;
                }

            }

            
        }
        if(move)
        {
            timer += Time.deltaTime;
            start = new Vector2(enemy.transform.position.x, enemy.transform.position.y);

            enemy.transform.position = Vector2.MoveTowards(start, end, speed * Time.deltaTime);
            //goesNext.GetComponent<SpriteRenderer>().sortingOrder = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            //if something is in way then move around it

            if (timer > seconds || (enemy.transform.position.x, enemy.transform.position.y) == (end.x, end.y))
            {
                move = false;
                timer = 0;
                StartCoroutine(Wait3());
            }
        }

        if (endturn)
        {

            enemy.speed = 0;
            this.GetComponent<Battle_Controller>().enabled = true;

            this.GetComponent<Enemy_AI_Manager>().enabled = false;
        }
       

        IEnumerator Wait()
        {
            
            yield return new WaitForSeconds(2f);
            Debug.Log("it has been 2 seconds");
            step1 = true;
        }
        IEnumerator Wait2()
        {

            yield return new WaitForSeconds(2f);
            Debug.Log("it has been 4 seconds");
            step1 = false;
            move = true;
            
        }
        IEnumerator Wait3()
        {

            yield return new WaitForSeconds(2f);
            Debug.Log("it has been 6 seconds");
            endturn = true;

        }
    }
}
