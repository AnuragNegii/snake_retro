using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snake_Movement : MonoBehaviour
{
    private Vector2 direction_snake = Vector2.right;
    private float speed = 1.0f;
    public List<Transform> component  = new List<Transform>();
    [SerializeField] private GameObject body;


    private void Awake(){
        component.Add(this.transform);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.W) && direction_snake != Vector2.down){
            direction_snake = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S) && direction_snake != Vector2.up){
            direction_snake = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.D) && direction_snake != Vector2.left){
            direction_snake = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.A) && direction_snake != Vector2.right){
            direction_snake = Vector2.left;
        }

    }

    void FixedUpdate()
    {
        for (int i = component.Count - 1; i > 0; i--){
            component[i].transform.position = component[i-1].transform.position;
        }
        component[0].position += new Vector3(direction_snake.x, direction_snake.y, 0) * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Wall")){
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.CompareTag("Food")){
            Grow();
        }
    }

    private void Grow()
    {
        GameObject segment = Instantiate(body, transform.position, Quaternion.identity);
        segment.transform.position = component[component.Count - 1].position;
        component.Add(segment.transform);
    }
}


