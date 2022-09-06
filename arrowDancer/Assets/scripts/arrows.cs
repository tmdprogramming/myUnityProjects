using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arrows : MonoBehaviour
{
    public float speed;
    public bool isColorLessThan1 = true;
    public bool isColorHigh = false;
    public bool isTransparencyLessThan1 = true;
    public bool isTransparencyHigh = false;
    public float colorValue;
    public float transparencyValue;
    // Start is called before the first frame update
    void Start()
    {
     colorValue = Random.Range((float)0.75, (float)0.9);
    transparencyValue = Random.Range((float)0.85, (float)0.95);
}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = gameObject.GetComponent<Rigidbody2D>().position;
        
        position.y = position.y + speed * Time.deltaTime;

        gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
        if(isColorLessThan1)
        {
            colorValue += Time.deltaTime;
        }
        if(isColorHigh)
        {
            colorValue -= Time.deltaTime;
        }
        if(colorValue > (float)0.80)
        {
            isColorHigh = true;
            isColorLessThan1 = false;
        }
        if (colorValue < (float)0.40)
        {
            isColorHigh = false;
            isColorLessThan1 = true;
        }

      /*  if (isTransparencyLessThan1)
        {
            transparencyValue += Time.deltaTime;
        }
        if (isTransparencyHigh)
        {
            transparencyValue -= Time.deltaTime;
        }
        if (transparencyValue > (float).95)
        {
            isTransparencyHigh = true;
            isTransparencyLessThan1 = false;
        }
        if (transparencyValue < (float)0.9)
        {
            isTransparencyHigh = false;
            isTransparencyLessThan1 = true;
        }*/
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colorValue, 0, (float)(1.1 - colorValue), 1);


    }
}
