using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour {
    private int x_clamp = 25;
    private int y_clamp = 14;
    GameObject snake;
    List<Transform> snake_body = new List<Transform>();
    private void Awake() {
        transform.position = new Vector3(Random.Range(-x_clamp, x_clamp), Random.Range(-y_clamp, y_clamp), 0);
        snake = FindObjectOfType<snake_Movement>().GameObject();
        snake_body = snake.GetComponent<snake_Movement>().component;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            transform.position = newpos();
        }
    }

    private Vector3 newpos()
    {
        Vector3 foodPosition;
        do{
            foodPosition = new Vector3(Random.Range(-x_clamp, x_clamp), Random.Range(-y_clamp, y_clamp), 0);
        }while(IsFoodInsideSnakeBody(foodPosition));

        return foodPosition;
    }

    private bool IsFoodInsideSnakeBody(Vector3 foodPosition){
    foreach (Transform bodyPart in snake_body){
        if (bodyPart.position == foodPosition)
        {
            return true;
        }
    }
        return false;
    }

}
