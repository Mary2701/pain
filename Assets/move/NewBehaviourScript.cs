using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
    //основные параметры
    public float speedMove;//скорость объекта
    public float jumpPower;//сила прыжка

    //параметры геймплэ€ дл€ объекта
    private float gravityForce;//гравитаци€
    private Vector3 moveVector;//направление движени€ объекта
    //ссылки на компаненты
    private CharacterController ch_controller;
    private Animator ch_animator;
    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();

    }
    private void Update()
    {
        CharacterMove();
        GamingGravity();
    }
    //метод перемещени€ персонажа
    private void CharacterMove()

    {
        if (ch_controller.isGrounded)
            moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        moveVector.y = gravityForce;
        ch_controller.Move(moveVector * Time.deltaTime);
    }
    //метод гравитации
    private void GamingGravity()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
        if (Input.GetKeyDown(KeyCode.Space) && ch_controller.isGrounded) gravityForce = jumpPower;
    }
}