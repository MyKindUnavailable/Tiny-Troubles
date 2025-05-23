using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 targetPos;

    public GameObject ways;

    public Transform[] wayPoints;
    int pointIndex;
    int PointCount;
    int direction = 1;


    private void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++) 
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        PointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos) 
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (pointIndex == PointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
}
