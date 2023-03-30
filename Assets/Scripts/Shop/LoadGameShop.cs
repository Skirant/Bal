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

        bool[] _sale = Progress.Instance.PlayerInfo._saleBall; // получаем массив _sale
        GameObject[] shopItemSO = this.shopItemSO.Select(so => so.ballPrefab).ToArray(); // получаем массив shopItemSO
        List<GameObject> filteredItems = new List<GameObject>(); // создаем список для отфильтрованных элементов
        for (int i = 0; i < _sale.Length; i++) // перебираем все элементы _sale
        {
            if (_sale[i]) // если элемент равен true
            {
                filteredItems.Add(shopItemSO[i]); // добавляем соответствующий элемент из shopItemSO в список
            }
        }
        List<GameObject> existingItems = new List<GameObject>(spawnBall.ballPrefab); // создаем список из существующих элементов в spawnBall
        existingItems.AddRange(filteredItems); // добавляем отфильтрованные элементы к существующим элементам

        spawnBall.ballPrefab = existingItems.Distinct().ToArray(); // применяем метод Distinct без параметра и присваиваем результат в spawnBall
    }
}
