using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class bird : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject target;
    private float currentAngle;
    private float radius;
    private float speed = 100f;
    private SpriteRenderer sprite;

    void Start()
    {
        radius = Vector3.Distance(transform.position, target.transform.position);
        sprite = GetComponent<SpriteRenderer>();
        float xtarget = transform.position.x - target.transform.position.x;
        float ytarget = transform.position.y - target.transform.position.y;

        currentAngle = Mathf.Atan2(xtarget,ytarget) * Mathf.Rad2Deg;


    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += speed * Time.deltaTime;
        if (currentAngle > 360f)
        {
            currentAngle = 0f;
        }


        
        if (90f < currentAngle && currentAngle <270f)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }

        float xOffset = radius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float yOffset = radius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector3 newPosition = target.transform.position + new Vector3(xOffset, yOffset, 0);
        //transform.RotateAround(target.transform.position, new Vector3(0,0,1), 100 * Time.deltaTime);

        transform.position = newPosition;
        transform.LookAt(newPosition);
    }
}
