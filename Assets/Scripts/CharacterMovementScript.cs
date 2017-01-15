using UnityEngine;

/// <summary>
/// This class manage the movement of characters in the game
/// It is based on rigidbody physics so it required a rigidbody in te scene.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovementScript : AbstractControllable {

    //Parameters
    [SerializeField]
    private float maxSpeed = 50;
    [SerializeField]
    private float jumpForce = 10f;

    private bool isGrounded;

    //Component References
    private Rigidbody rigid;
    private SphereCollider footCollider;

    public void Awake()
    {
        Physics.gravity *= 2;
        rigid = GetComponent<Rigidbody>();
        footCollider = GetComponentInChildren<SphereCollider>();
    }

    void FixedUpdate()
    {
        isGrounded = false;
        Collider[] colliders = Physics.OverlapSphere(footCollider.transform.position, footCollider.radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject.tag != gameObject.tag)
            {
                isGrounded = true;
            }
        }
    }

    public override void Control(float horizontal, float vertical, bool jump)
    {

        if (jump)
        {
            if (isGrounded)
            {
                isGrounded = false;
                rigid.AddForce(Vector3.up * jumpForce);
            }
        }

        rigid.velocity = new Vector3(horizontal * maxSpeed, rigid.velocity.y, 0);
    }
    
}
