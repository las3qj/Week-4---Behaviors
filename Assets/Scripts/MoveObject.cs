using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour // MoveObject inherits from MonoBehaviour; anything which will become a component will also
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] GameObject stationarySphere;
    [SerializeField] float totalMoveDistance;

    Vector3 startingLocation;   

    // These next two are inherited from MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        startingLocation = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTraveled = GetDistanceTraveled();

        if (distanceTraveled > totalMoveDistance)
        {
            FlipMoveDirection();
            startingLocation = gameObject.transform.position;
            this.enabled = false;
        }
        else
        {
            gameObject.transform.Translate(moveDirection * moveSpeed);
        }

    }

    void FlipMoveDirection()
    {
        moveDirection = -moveDirection;
    }

    float GetDistanceTraveled()
    {
        return Vector3.Distance(gameObject.transform.position, startingLocation);
    }
}
