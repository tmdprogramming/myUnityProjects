using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            other.transform.position = new Vector3(other.transform.position.x + 1f, other.transform.position.y, other.transform.position.z);
        }
    }
}
