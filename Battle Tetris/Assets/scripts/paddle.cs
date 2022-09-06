using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - 1f, this.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + 1f, this.transform.position.y, this.transform.position.z);
        }


       
    }

}
