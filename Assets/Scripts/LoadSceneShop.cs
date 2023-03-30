using UnityEngine;

public class LoadSceneShop : MonoBehaviour
{
    public bool[] _sale;

    private void Start()
    {
        if (Progress.Instance.PlayerInfo._saleBall != null)
        {
            _sale = Progress.Instance.PlayerInfo._saleBall;
        }
    }

    public void Purchase(int batNo)
    {
        _sale[batNo] = true;
        Progress.Instance.PlayerInfo._saleBall = _sale;
    }
}
