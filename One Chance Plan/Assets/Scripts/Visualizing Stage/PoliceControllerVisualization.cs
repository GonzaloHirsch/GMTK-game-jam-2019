using System.Collections.Generic;
using UnityEngine;

public class PoliceControllerVisualization : Police
{
    public List<Vector2> positions;
    public List<Vector2> alternativePosition;
    public float velocity = 3f;
    public float smoothFactor = 0.75f;

    private int positionsIndex = 0;
    private Vector3 nextPosition;
    private float distance;
    private List<Vector2> activePositions;
    private const float EPSILON = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;

        activePositions = positions;

        DrawMesh();
    }

    private void RotateView()
    {
        Vector3 direction = (nextPosition - transform.position).normalized;

        if (System.Math.Abs(direction.x - 1) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 270) - transform.rotation.eulerAngles);
        } else if (System.Math.Abs(direction.x - (-1)) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 90) - transform.rotation.eulerAngles);
        } else if (System.Math.Abs(direction.y - 1) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 360) - transform.rotation.eulerAngles);
        } else if  (System.Math.Abs(direction.y - (-1)) < EPSILON)
        {
            transform.Rotate(new Vector3(0, 0, 180) - transform.rotation.eulerAngles);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (!AreSameVectors(nextPosition, transform.position))
            {
                UpdateMovement();
            }
            else if (AreSameVectors(nextPosition, transform.position))
            {
                NextMovement();
                RotateView();
            }
        }
    }

    public void ChangePositions(int id)
    {
        switch (id)
        {
            case 1:
                activePositions = positions;
                break;
            case 2:
                activePositions = alternativePosition;
                break;
        }
        positionsIndex = 0;
    }

    private void UpdateMovement()
    {
        float step = velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);
    }

    private void NextMovement()
    {
        nextPosition = transform.position + (Vector3)activePositions[positionsIndex];

        distance = Mathf.Abs((transform.position - nextPosition).magnitude);

        positionsIndex = (positionsIndex + 1) % activePositions.Count;
    }

    private bool AreSameVectors(Vector3 a, Vector3 b)
    {
        return Mathf.Abs((a - b).magnitude) < 0.05f;
    }
}
