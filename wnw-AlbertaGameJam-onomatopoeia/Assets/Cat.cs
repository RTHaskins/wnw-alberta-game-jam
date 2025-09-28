using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Rendering;


// Cat will try escaping the apartment by chasing the bird around it and try to escape it
public class Cat : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    public Text resultText;
    [SerializeField]
    public float speed;

    float speedx, speedy;
    private Rigidbody2D rb;

    InputAction moveAction;
    InputAction leapAction;
    InputAction bombAction;
    private Vector2 velocity;
    private Vector2 lastVelocity;
    private float damping = 0.80f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        leapAction = InputSystem.actions.FindAction("Leap");
        bombAction = InputSystem.actions.FindAction("Bomb");

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = rb.linearVelocity;


        //Vector2 moveValue = moveAction.ReadValue<Vector2>();
        //speedx = moveValue.x * speed;
        //speedy = moveValue.y * speed;
        //velocity = new Vector2(speedx, speedy);
        //rb.linearVelocity = velocity;
        

        if(leapAction.WasPressedThisFrame() || resultText.text == "CHIRP")
        {
            var leapDirection = (bird.transform.position - transform.position).normalized;
            velocity = new Vector2(speed, speed) * leapDirection;
            rb.linearVelocity = velocity;
            resultText.text += " ";
        }

        


        lastVelocity = velocity;


    }
}
