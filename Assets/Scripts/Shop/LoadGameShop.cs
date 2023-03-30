using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadGameShop : MonoBehaviour
{
    public ShopItemSO[] shopItemSO;
    public SpawnBall spawnBall;

    private void Start()
    {
        spawnBall = FindObjectOfType<SpawnBall>();

        bool[] _sale = Progress.Instance.PlayerInfo._saleBall; // �������� ������ _sale
        GameObject[] shopItemSO = this.shopItemSO.Select(so => so.ballPrefab).ToArray(); // �������� ������ shopItemSO
        List<GameObject> filteredItems = new List<GameObject>(); // ������� ������ ��� ��������������� ���������
        for (int i = 0; i < _sale.Length; i++) // ���������� ��� �������� _sale
        {
            if (_sale[i]) // ���� ������� ����� true
            {
                filteredItems.Add(shopItemSO[i]); // ��������� ��������������� ������� �� shopItemSO � ������
            }
        }
        List<GameObject> existingItems = new List<GameObject>(spawnBall.ballPrefab); // ������� ������ �� ������������ ��������� � spawnBall
        existingItems.AddRange(filteredItems); // ��������� ��������������� �������� � ������������ ���������

        spawnBall.ballPrefab = existingItems.Distinct().ToArray(); // ��������� ����� Distinct ��� ��������� � ����������� ��������� � spawnBall
    }
}
