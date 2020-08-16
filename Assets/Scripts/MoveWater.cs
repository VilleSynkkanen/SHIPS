using UnityEngine;

public class MoveWater : MonoBehaviour
{
    [SerializeField] Transform water;
    [SerializeField] float speed;
    [SerializeField] Vector2 direction;
    [SerializeField] float directionSwapInterval;
    [SerializeField] float directionSwapPerSecond;
    
    float lastDirectionSwapTime;
    int swappingDirection;      // -1, 0 or 1
    float currentDirection;

    private void Start()
    {
        lastDirectionSwapTime = Time.time;
        currentDirection = 1;
        swappingDirection = 0;
    }

    void Update()
    {
        if(swappingDirection != 0)
        {
            currentDirection += directionSwapPerSecond * swappingDirection * Time.deltaTime;
            if(Mathf.Abs(currentDirection) >= 1)
            {
                swappingDirection = 0;
                currentDirection = Mathf.Clamp(currentDirection, -1, 1);
            }
        }
        
        water.Translate(currentDirection * direction * speed * Time.deltaTime);
        if(Time.time - lastDirectionSwapTime >= directionSwapInterval)
        {
            lastDirectionSwapTime = Time.time;
            swappingDirection = -(int)currentDirection;
        }
    }
}
