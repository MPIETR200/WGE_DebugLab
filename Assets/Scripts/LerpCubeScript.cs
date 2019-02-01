using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCubeScript : MonoBehaviour {

    public GameObject _cube;
    public Vector3 _leftPosition;
    public Vector3 _rightPosition;

    public void StartLerp()
    {

        _cube.transform.position = _leftPosition;

        StartCoroutine(LerpCube());

    }

    IEnumerator LerpCube()
    {
        System.Diagnostics.Stopwatch stopWatch =
            new System.Diagnostics.Stopwatch();
        stopWatch.Start();
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            _cube.transform.position = Vector3.Lerp(_leftPosition, _rightPosition, t);
            if(t >=1)
            {
                _cube.transform.position = _rightPosition;
            }
            yield return null;
        }
        stopWatch.Stop();
        Debug.Log("Time taken: " + (stopWatch.Elapsed));
    }

    //inseert code here:
    public void PrintDebugString()
    {
        Debug.Log(this.ToString());
    }
    public override string ToString()
    {
        string s;
        s = (_cube ? "Cube position = " + _cube.transform.position : "Cube not instantieted") + "\n"
            + "Left Position =" + _leftPosition + "\n"
            + "Right Position = " + _rightPosition;
        return s;
    }
}
