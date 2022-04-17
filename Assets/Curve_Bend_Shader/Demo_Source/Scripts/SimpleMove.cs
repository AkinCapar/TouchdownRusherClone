namespace CurioAssets
{
    using UnityEngine;
    public class SimpleMove : MonoBehaviour
    {
        public GameObject bendC;
        const int speed = 20, gravity = 1;
        private Vector3 moveDirection = Vector3.zero;

        Vector3 defPos;
        private void Awake()
        {
            defPos = transform.localPosition;
        }
        private void OnEnable()
        {
            transform.localPosition = defPos;
        }

        void Update()
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bendC.SendMessage("ChangeCurve" + UIManager.Instance.ExampleId);
            }
        }
    }
}