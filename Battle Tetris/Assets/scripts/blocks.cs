using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
 
    public RaycastHit hit_left;
    public RaycastHit hit_left_2;
    public RaycastHit hit_up;
    public RaycastHit hit_up_2;
    public RaycastHit hit_down;
    float laserLength = 1f;
    public bool left;
    public bool up;
    public bool empty;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Physics.Raycast(transform.position - new Vector3(-.5f, 0, 0), Vector2.left, out hit_left, laserLength) && hit_left.transform.tag == this.gameObject.transform.tag)
            {
                if (Physics.Raycast(hit_left.transform.position - new Vector3(-.5f, 0, 0), Vector2.left, out hit_left_2, laserLength) && hit_left_2.transform.tag == this.gameObject.transform.tag)
                {
                    left = true;
                }
              
            }
            
       
        {
          if (!(Physics.Raycast(transform.position, Vector2.left, out hit_left, laserLength) && hit_left.transform.tag == this.gameObject.transform.tag))
            {
                //Hit something, print the tag of the object
                
                left = false;
            }
        }

        if (Physics.Raycast(transform.position - new Vector3(0, .5f, 0), Vector2.up, out hit_up, laserLength) && hit_up.transform.tag == this.gameObject.transform.tag)
        {
            if (Physics.Raycast(hit_up.transform.position - new Vector3(0, .5f, 0), Vector2.up, out hit_up_2, laserLength) && hit_up_2.transform.tag == this.gameObject.transform.tag)
            {
                up = true;
            }
           
        }


        {
            if (!(Physics.Raycast(transform.position, Vector2.up, out hit_up, laserLength) && hit_up.transform.tag == this.gameObject.transform.tag))
            {
                //Hit something, print the tag of the object

                up = false;
            }
        }
        
        if (!Physics.Raycast(transform.position , Vector2.down, out hit_down, 1f))
        {
            empty = true;
        }
        if (Physics.Raycast(transform.position, Vector2.down, out hit_down, .55f))
        {
            empty = false ;
        }
     
        if (empty)
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - .05f);
        }
        if (left) 
        {
            Destroy(this.gameObject);
            Destroy(hit_left.rigidbody.gameObject);
            Destroy(hit_left_2.rigidbody.gameObject);
        }
        if (up)
        {
            Destroy(this.gameObject);
           Destroy(hit_up.rigidbody.gameObject);
           Destroy(hit_up_2.rigidbody.gameObject);
        }
    }


}
