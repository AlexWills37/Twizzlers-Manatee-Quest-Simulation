using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFSM : MonoBehaviour
{
    enum State
    {
        Entering = 0,
        Idle = 1,
        Exiting = 2,
    }

    public float topSpeed;

    private Vector3 start;
    public Vector3 midPoint;

    private State state;

    public GameObject trashPrefab;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        midPoint.y = start.y;
        state = State.Exiting;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b")) StartCoroutine(Reset());

        if (state == State.Entering)
        {
            float speed = Mathf.Min(topSpeed, Vector3.Distance(transform.position, midPoint));
            Debug.Log(speed);
            transform.LookAt(midPoint);
            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
            transform.Translate(Vector3.forward*speed*Time.deltaTime);

            if (speed < 1)
            {
                state = State.Idle;
                StartCoroutine(ThrowTrash());
            }
        }
        else if (state == State.Exiting)
        {
            float speed = 1+Mathf.Min(topSpeed, Vector3.Distance(transform.position, midPoint));
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    IEnumerator ThrowTrash()
    {
        Instantiate(trashPrefab, transform.position, Quaternion.identity);
        Instantiate(trashPrefab, transform.position, Quaternion.identity);
        Instantiate(trashPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(10);
        state = State.Exiting;
        //StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        if (state != State.Exiting)
        {
            yield return new WaitForEndOfFrame();
        } else
        {
            //yield return new WaitForSeconds(20);

            state = State.Entering;
            transform.position = start;
        }
    }
}
