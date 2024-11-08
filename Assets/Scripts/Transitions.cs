using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey("w"))
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("running", true);
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("running", false);
        }
        if (Input.GetKey("space"))
        {
            anim.SetBool("jump", true);
        }
        if (!Input.GetKey("space"))
        {
            anim.SetBool("jump", false);
        }
    }
}
