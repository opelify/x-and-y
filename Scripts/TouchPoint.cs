using UnityEngine;

public class TouchPoint : MonoBehaviour {
    private TouchSystem sys;
    private SignControlSystem control;

    private void Awake() {
        sys = GameObject.Find("Touch System").GetComponent<TouchSystem>();
        control = GameObject.Find("Sign Control System").GetComponent<SignControlSystem>();
    }

    private void OnMouseDown() {
        Vector2 hey = transform.position / 3;
        int x_pos = -1;
        int y_pos = -1;
        
        switch (hey.y) {
            case 1: y_pos = 0; break;
            case 0: y_pos = 1; break;
            case -1: y_pos = 2; break;
        }
        switch (hey.x) {
            case 1: x_pos = 0; break;
            case 0: x_pos = 1; break;
            case -1: x_pos = 2; break;
        }

        sys.current_position[y_pos, x_pos] = 1;
        control.MovedSign(transform.position);
    }
}