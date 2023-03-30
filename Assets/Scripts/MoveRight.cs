using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] private float _moveSpeedMax;
    [SerializeField] private float _moveSpeedMin;


    private void Update()
    {
        transform.position += Vector3.right * (Random.Range(_moveSpeedMin, _moveSpeedMax)* Time.deltaTime);
    }
}
