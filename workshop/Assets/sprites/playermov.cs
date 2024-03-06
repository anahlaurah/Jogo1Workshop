using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermov : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 move;
    public float speed;

    private float inputX;
    private bool inputJump;

    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float forceJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputLogic();
        JumpLogic();
    }

    private void FixedUpdate(){
        MoveLogic();
    }

    public void InputLogic(){
        inputX = Input.GetAxisRaw("Horizontal");
        inputJump = Input.GetKeyDown(KeyCode.Space);
    }

    public void MoveLogic(){
        move = new Vector2(inputX * speed, rb.velocity.y);
        rb.velocity = move;
    }

   public Vector2 MoveValue
   {
    get { return move;}
    set { move = value;}
   }

    public bool InGround()
    {   
         return Physics2D.OverlapCircle(checkGround.position, 0.3f, LayerMask.GetMask("Ground"));
    }

    public void JumpLogic()
    {
        if (inputJump == true && InGround() == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, forceJump);
        }
    }











}




