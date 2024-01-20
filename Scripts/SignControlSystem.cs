using UnityEngine.InputSystem;
using UnityEngine;

public class SignControlSystem : MonoBehaviour {
    public GameObject active_sign = null;
    public float lerp_speed;
    Vector3 target_position;

    private Mouse mouse;
    private Vector3 mouse_position;

    public bool is_moving = false;

    public bool moved = false;

    private void Update() {
        mouse = Mouse.current;        
        mouse_position = Camera.main.ScreenToWorldPoint(mouse.position.value);
        mouse_position = new Vector3(mouse_position.x, mouse_position.y, 0);
        
        if (active_sign != null) {
            if (!moved) target_position = mouse_position;
            active_sign.transform.position = Vector3.Lerp(active_sign.transform.position, target_position, Time.deltaTime * lerp_speed);
        }

        if (active_sign != null && !(Vector3.Distance(target_position,active_sign.transform.position) <= 0.05f)) {
            is_moving = true;
        } else { is_moving = false; }

        if (moved == true && !is_moving) {
            moved = false;
            active_sign = null;
        }
    }

    public void MovedSign(Vector3 pos) {
        moved = true;
        target_position = pos;
    }
}