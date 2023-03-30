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
        // ���� ������ null, �� ���������� false
        if (obj == null)
            return false;

        // ������� �������� ������ � ���� ShopItemSO
        ShopItemSO other = obj as ShopItemSO;

        // ���� ���������� �� �������, �� ���������� false
        if (other == null)
            return false;

        // ���������� ��������� ��������� ����
        return this.name == other.name;
    }

    // �������������� ����� GetHashCode ��� ��������� ���-���� �� �����
    public override int GetHashCode()
    {
        // ���������� ���-��� �����
        return this.name.GetHashCode();
    }
}
