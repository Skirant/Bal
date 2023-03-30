using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //public GameObject ball;
    public Animator animator;

    //[SerializeField] GameObject _effectPrefab;

    private void OnMouseDown()
    {
        animator.SetTrigger("explosive");
        FindObjectOfType<CoinManager>().AddOne();

        FindObjectOfType<AudioManager>().Play("POP");

        TimerSlider timerSlider = FindObjectOfType<TimerSlider>();
        if (timerSlider != null)
        {
            timerSlider.RestartTimer();
        }

        //Instantiate(_effectPrefab, transform.position, transform.rotation);
    }

    void Dest()
    {
        Destroy(gameObject);
    }
}
