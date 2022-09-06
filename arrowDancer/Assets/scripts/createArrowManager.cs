using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createArrowManager : MonoBehaviour
{
    public GameObject upArrow;
    public GameObject upFreezeArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject upOrigin;
    public GameObject downOrigin;
    public GameObject leftOrigin;
    public GameObject rightOrigin;
    public GameObject thing;
    public Vector3 scaleChange;
    public GameObject baseArrow;


    // Start is called before the first frame update
    void Start()
    {
      
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            baseArrow =Instantiate(upArrow,upOrigin.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            Vector2 vector = new Vector2(baseArrow.GetComponent<Rigidbody2D>().position.x, baseArrow.GetComponent<Rigidbody2D>().position.y/2);
            thing = Instantiate(upFreezeArrow, vector, Quaternion.identity);
            scaleChange = new Vector3(0, baseArrow.GetComponent<Rigidbody2D>().position.y, 0);
            thing.transform.localScale += scaleChange;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            baseArrow = Instantiate(leftArrow, leftOrigin.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            Vector2 vector = new Vector2(baseArrow.GetComponent<Rigidbody2D>().position.x, baseArrow.GetComponent<Rigidbody2D>().position.y / 2);
            thing = Instantiate(upFreezeArrow, vector, Quaternion.identity);
            scaleChange = new Vector3(0, baseArrow.GetComponent<Rigidbody2D>().position.y, 0);
            thing.transform.localScale += scaleChange;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            baseArrow = Instantiate(downArrow, downOrigin.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            Vector2 vector = new Vector2(baseArrow.GetComponent<Rigidbody2D>().position.x, baseArrow.GetComponent<Rigidbody2D>().position.y / 2);
            thing = Instantiate(upFreezeArrow, vector, Quaternion.identity);
            scaleChange = new Vector3(0, baseArrow.GetComponent<Rigidbody2D>().position.y, 0);
            thing.transform.localScale += scaleChange;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            baseArrow = Instantiate(rightArrow, rightOrigin.GetComponent<Rigidbody2D>().position, Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            Vector2 vector = new Vector2(baseArrow.GetComponent<Rigidbody2D>().position.x, baseArrow.GetComponent<Rigidbody2D>().position.y / 2);
            thing = Instantiate(upFreezeArrow, vector, Quaternion.identity);
            scaleChange = new Vector3(0, baseArrow.GetComponent<Rigidbody2D>().position.y, 0);
            thing.transform.localScale += scaleChange;

        }
    }
}
