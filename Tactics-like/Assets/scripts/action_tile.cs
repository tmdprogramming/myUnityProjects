using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action_tile : MonoBehaviour
{
    public GameObject controller;
    
    
    public int shared;
    // Start is called before the first frame update
    void Start()
    {
        controller= GameObject.FindWithTag("controller");
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.GetComponent<Battle_Controller>().menu.menu_no == true || Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.B) || controller.GetComponent<Enemy_AI_Manager>().move == true)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nomove"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("moveup"))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + .5f);
            this.GetComponent<SpriteRenderer>().sortingOrder++;
        }
    }
    
}
