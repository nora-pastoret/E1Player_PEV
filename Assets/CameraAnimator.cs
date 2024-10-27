using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAnimator : MonoBehaviour
{
    InputControlers _inputs;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        _inputs = GetComponent<InputControlers>();
    }


    private void Zoom(bool isZooming)
    {
        anim.SetBool("Zoommed", isZooming);
        
    }

    private bool ShouldZoom()
    {
        //return Input.GetKeyDown(KeyCode.Z);
        return _inputs.Zoom;
        //_runstart = Keyboard.current.shiftKey.isPressed;
    }


    // Update is called once per frame
    void Update()
    {
        if (ShouldZoom())
            Zoom();
        
    }
}
//public class Test : MonoBehaviour
//{
//    Animator anim;
//    void Start()
//    {
//        anim = gameObject.GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Jotaro Idle"))
//        {
//            if (Input.GetKey(KeyCode.D))
//                anim.SetTrigger("WalkRightfromIdle");
//            else if (Input.GetKey(KeyCode.A))
//                anim.SetTrigger("WalkLeftFromIdle");
//        }
//    }
//}