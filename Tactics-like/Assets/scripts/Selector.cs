using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public int top_boundary;
    public int bottom_boundary;
    public int move;
    public Menu_Manager menu;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        menu.top_boundary = top_boundary;
        menu.bottom_boundary = bottom_boundary;
        menu.move = move;
        menu.menu_selector = this.gameObject;
    }
}
