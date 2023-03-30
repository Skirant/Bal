using UnityEngine;

public class LoadSceneBackGround : MonoBehaviour
{
    public bool[] _sale;

    private void Start()
    {
        if(Progress.Instance.PlayerInfo._saleBackground != null)
        {
            _sale = Progress.Instance.PlayerInfo._saleBackground;
        }
    }

    public void Purchase(int batNo)
    {
        _sale[batNo + 1] = true;
        Progress.Instance.PlayerInfo._saleBackground = _sale;
    }
}
