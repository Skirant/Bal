using UnityEngine;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable oject/new shop item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public string titleEn;
    public string titleRu;
    public int baseCost;
    public GameObject ballPrefab;

    public override bool Equals(object obj)
    {
        // Если объект null, то возвращаем false
        if (obj == null)
            return false;

        // Пробуем привести объект к типу ShopItemSO
        ShopItemSO other = obj as ShopItemSO;

        // Если приведение не удалось, то возвращаем false
        if (other == null)
            return false;

        // Возвращаем результат сравнения имен
        return this.name == other.name;
    }

    // Переопределяем метод GetHashCode для получения хеш-кода по имени
    public override int GetHashCode()
    {
        // Возвращаем хеш-код имени
        return this.name.GetHashCode();
    }
}
