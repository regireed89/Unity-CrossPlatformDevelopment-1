using System;
using UnityEngine;

[Serializable]
public class PlayerInputBehaviour : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    public bool rootMotion;
    public float jumpPower = 600f;
    public float scaleF;

    public float speed = 15f;
    public Vector3 startScale;
    public Vector3 Velocity;

    public Vector3 Move { get; set; }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        scaleF = transform.localScale.x;
    }

    void Update()
    {
        if (rootMotion)
            return;
            
        
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Move =  new Vector3(h, v, 0);

        var dir = Move.normalized;
        
        Velocity = dir * speed;

        var dot = Vector3.Dot(dir, transform.right);

        if (_rigidbody2D.velocity.magnitude > 0)
        {
            if (dot < 0)
                SetScaleX(transform, -scaleF);
            else if (dot > 0)
                SetScaleX(transform, scaleF);
        }


        _rigidbody2D.velocity = new Vector3(Move.x * speed, _rigidbody2D.velocity.y, 0);
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetTrigger("kick");
          
        }

        if (Input.GetButtonDown("Fire2"))
        {
        }


        if (Input.GetButtonDown("Fire3"))
        {
            _animator.SetTrigger("punch"); //x key            
           
        }

        if (Input.GetAxis("Slide") > 0)
            _animator.SetTrigger("slide"); //r trigger axis 10

        if (Input.GetAxis("Block") > 0)
            print("Block" + " :: " + Input.GetAxis("Block"));
        if (Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("jump");
            _rigidbody2D.AddForce(new Vector2(0, jumpPower));
        }
    }

    void OnAnimatorMove()
    {
        rootMotion = (_animator.deltaPosition.magnitude > 0) ? true : false;
        transform.position = _animator.rootPosition;
    }

    public static void SetScaleX(Transform t, float val)
    {
        var scale = t.localScale;
        scale.x = val;
        t.localScale = scale;
    }
}