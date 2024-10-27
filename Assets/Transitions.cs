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
        if (Input.GetKey("w"))
        {
            anim.SetBool("move", true);
        }
        if (!Input.GetKey("w"))
        {
            anim.SetBool("move", false);
        }
        if (Input.GetKey("shift"))
        {
            anim.SetBool("running", true);
        }
        if (!Input.GetKey("shift"))
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
