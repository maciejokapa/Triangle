using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    //Camera 20 x 9

    public int maxPoints;
    private int pointsCnt;

    public GameObject point;

    public int points;
    private Vector3[] vertex;

    private Vector3 offset;
    private Vector3 lastPoint;

    void GenerateRectangle ()
    {
        for (int i = 0; i < vertex.Length; i++)
        {
            int x = Random.Range(-20, 20);
            int y = Random.Range(-9, 9);
            Vector3 pos = new Vector3(x, y, 0);
            Instantiate(point, pos, Quaternion.identity);
            vertex[i] = pos;
        }
    }

    void GenerateFirstPoint ()
    {
        lastPoint = new Vector3(Random.Range(-15, 15), Random.Range(-8, 8), 0);
        Instantiate(point, lastPoint, Quaternion.identity);
    }

    private void Start()
    {
        vertex = new Vector3[points];
        GenerateRectangle();
        GenerateFirstPoint();
        pointsCnt = 0;
    }

    private void Update()
    {
        if (pointsCnt < maxPoints)
        {
            int n = Random.Range(0, vertex.Length);
            offset = (vertex[n] - lastPoint) / 2;
            lastPoint = lastPoint + offset;
            Instantiate(point, lastPoint, Quaternion.identity);
            pointsCnt++;
        }

    }
}
