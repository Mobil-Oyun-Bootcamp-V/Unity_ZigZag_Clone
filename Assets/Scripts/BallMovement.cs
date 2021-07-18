using UnityEngine;

public static class BallMovement
{
    private static Vector3 _direction;
    private static float _speed = 3f;
    public static void MoveWithTap(Transform transform, bool isGameOver)
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isGameOver == false)
        {     
            if (_direction == Vector3.forward)
                _direction = Vector3.left;
            else _direction = Vector3.forward;
            Score.Scored();
        }
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
}
