using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoliceControllerVisualization : MonoBehaviour
{
    public List<Vector2> positions;
    public bool isActive = true;
    public float velocity = 3f;
    public float smoothFactor = 0.75f;
    public float awarenesFactor = 1f;

    private int positionsIndex = 0;
    private Tweener activeTweener;
    private float timeBewtweenMovements;
    private Vector3 nextPosition;
    private float distance;

    private const float EPSILON = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = transform.position;
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
        if (isActive && !AreSameVectors(nextPosition, transform.position))
        {
            UpdateMovement();
        } else if (AreSameVectors(nextPosition, transform.position))
        {
            NextMovement();
            RotateView();
        }

        /*
        if (isActive && ((activeTweener != null && activeTweener.IsComplete()) || activeTweener == null))
        {
            UpdateMovement();
        }
        */
    }

    private void UpdateMovement()
    {
        float step = velocity * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);

        //transform.position = Vector3.Lerp(transform.position, nextPosition, smoothFactor * Time.deltaTime / distance);

        /*
        timeBewtweenMovements = CalculateTime(transform.position, transform.position + ToVector3(positions[positionsIndex]));

        Debug.Log(timeBewtweenMovements);

        activeTweener = transform.DOMove(transform.position + ToVector3(positions[positionsIndex]), timeBewtweenMovements, true)
            .OnComplete(() => {
            activeTweener = null;
        }

                );

*/
        //positionsIndex = (positionsIndex + 1) % positions.Count;
    }

    private void NextMovement()
    {
        nextPosition = transform.position + ToVector3(positions[positionsIndex]);

        distance = Mathf.Abs((transform.position - nextPosition).magnitude);

        positionsIndex = (positionsIndex + 1) % positions.Count;
    }

    private float CalculateTime(Vector3 start, Vector3 end)
    {
        return (end - start).magnitude / velocity;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerControllerVisualization>().RaiseAwareness(awarenesFactor);
        }
    }

    private bool AreSameVectors(Vector3 a, Vector3 b)
    {
        return Mathf.Abs((a - b).magnitude) < 0.05f;
    }

    private Vector3 ToVector3(Vector2 vector)
    {
        return new Vector3()
        {
            x = vector.x,
            y = vector.y,
            z = 0
        };
    }
}
