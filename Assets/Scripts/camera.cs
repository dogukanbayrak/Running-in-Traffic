using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }

    void Update()
    {

    }
}
