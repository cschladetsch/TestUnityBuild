using UnityEngine;

public class SmokeTest : MonoBehaviour
{
    public int NumSteps;

    void Awake() {
        Debug.Log(string.Format("{0}", "SmokeTest"));
    }

    void Start() {
        Debug.Log(string.Format("{0}", "SmokeTest.Start"));
    }

    void OnDestroy() {
        Debug.Log(string.Format("{0}", "SmokeTest.Destroyed"));
    }

    void Update() {
        if (Time.frameCount > NumSteps) {
            UnityEngine.Application.Quit(0);
            DestroyImmediate(gameObject);
	    }

        Debug.Log(string.Format("{0}", Time.frameCount));
    }
}

