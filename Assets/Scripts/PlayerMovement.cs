using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;
    private SpriteRenderer srenderer;
    [SerializeField] private float jumpspeed = 14;
    [SerializeField] private float movespeed = 7;
    // Start is called before the first frame update

    void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        //jumpspeed = new Vector3(0,14,0);
    }

    // Update is called once per frame
    void Update()
    {
        float hvelocity = Input.GetAxisRaw("Horizontal");
        rbody.velocity = new Vector2(hvelocity * movespeed,rbody.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            rbody.velocity = new Vector3(rbody.velocity.x, jumpspeed, 0);
        }
        UpdateAnimationState(hvelocity);

    }
    private void UpdateAnimationState(float hvelocity)
    {
        if(hvelocity > 0f)
        {
            anim.SetBool("is_running",true);
            srenderer.flipX = false;    
        }
        else if (hvelocity < 0f)
        {
            anim.SetBool("is_running",true);
            srenderer.flipX = true;
        }
        else 
        {
            anim.SetBool("is_running",false);
        }

    }
}
