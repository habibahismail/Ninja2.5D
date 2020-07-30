using UnityEngine;

namespace bebaSpace
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private float speed = 8;
        [SerializeField] private float jumpForce = 10;
        [SerializeField] private float gravity = -20;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        private bool canDoubleJump = true;
        private bool isGrounded = true;
        private Vector3 direction;
        private CharacterController controller;
        private Animator anim;
        private Transform playerModel;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponentInChildren<Animator>();
            playerModel = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
        }

        void Update()
        {
            float hInput = Input.GetAxis("Horizontal");
            direction.x = hInput * speed;

            isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            anim.SetBool("isGrounded", isGrounded);

            float previousX = 0;
            if (transform.position.z == 0)
                previousX = transform.position.x;


            if (isGrounded) {

                direction.y = -1;
                canDoubleJump = true;

                if (Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime;

                if (canDoubleJump && Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;

                    anim.SetTrigger("doDoubleJump");
                    canDoubleJump = false;
                }
            }

            if (hInput != 0)
            {
                ChangePlayerRotation(hInput);
                
            }

            anim.SetFloat("moveSpeed", Mathf.Abs(hInput));

            controller.Move(direction * Time.deltaTime);

            if (transform.position.z != 0)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = previousX;
                newPosition.z = 0;
                transform.position = newPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("throwWeapon");

                if (Input.mousePosition.x > Screen.width * 0.5f)
                {
                    //Right side.
                    ChangePlayerRotation(1);
                }
                else
                {
                    //Left side.
                    ChangePlayerRotation(-1);
                }
            }

        }

        private void ChangePlayerRotation(float xPos)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(xPos, 0, 0));
            playerModel.rotation = newRotation;
        }
        
    }
}
