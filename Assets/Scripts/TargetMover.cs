using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	// define the possible states through an enumeration
	public enum motionDirections {spinAndVertical, Horizontal, Vertical};
	
	// store the state
	private motionDirections motionState = motionDirections.Horizontal;

	// motion parameters
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

    void Start()
    {
        int Rand = Random.Range(0, 2);
        switch(Rand)
        {
            case 0:
                motionState = motionDirections.spinAndVertical;
                break;
            case 1:
                motionState = motionDirections.Horizontal;
                break;
            case 2:
                motionState = motionDirections.Vertical;
                break;
        }
    }

    // Update is called once per frame
    void Update () {

		// do the appropriate motion based on the motionState
		switch(motionState) {
			case motionDirections.spinAndVertical:
				// rotate around the up axix and translate up and down of the gameObject
				gameObject.transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
			
			case motionDirections.Vertical:
				// move up and down over time
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;

            case motionDirections.Horizontal:
                // move up and down over time
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
		}
	}
}
