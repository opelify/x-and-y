using UnityEngine.InputSystem;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject sign_prefab;

    private bool o_turn = true;

    [SerializeField] private SignControlSystem control;

    private void Awake() {
        InitSpawn();
    }

    private void Update() {
        if (Keyboard.current.wKey.wasPressedThisFrame && !control.is_moving) {
            InitSpawn();
        }
    }

    private void InitSpawn() {
        o_turn = o_turn ? false : true;
        if (gameObject.name == "O Spawner" && o_turn == true) {
            control.active_sign = Instantiate(sign_prefab, transform.position, Quaternion.identity);
        } else if (gameObject.name == "X Spawner" && o_turn == false) {
            control.active_sign = Instantiate(sign_prefab, transform.position, Quaternion.identity);
        }
    }
}