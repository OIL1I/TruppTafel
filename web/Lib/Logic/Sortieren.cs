namespace web.Lib.Logic;

public enum SortierOrdnung
{
    Alphabet,
    Ausbildung
}

public static class Sortieren
{
    public static List<T> Sort<T>(List<T> zuSortieren) where T : IComparable<T>
    {
        if (zuSortieren == null || zuSortieren.Count <= 1)
            return zuSortieren;

        T[] zuSortArr = zuSortieren.ToArray();
        QuickSort(zuSortArr, 0, zuSortArr.Length - 1);
        return zuSortArr.ToList();
    }

    private static void QuickSort<T>(T[] array, int links, int rechts) where T : IComparable<T>
    {
        if (links < rechts)
        {
            int teiler = Teile(array, links, rechts);
            QuickSort(array, links, teiler - 1);
            QuickSort(array, teiler + 1, rechts);
        }
    }

    private static int Teile<T>(T[] array, int links, int rechts) where T : IComparable<T>
    {
        T pivot = array[rechts];
        int i = links - 1;

        for (int j = links; j < rechts; j++)
        {
            if (array[j].CompareTo(pivot) <= 0)
            {
                i++;
                Tausche(array, i, j);
            }
        }

        Tausche(array, i + 1, rechts);
        return i + 1;
    }

    private static void Tausche<T>(T[] array, int index1, int index2)
    {
        (array[index1], array[index2]) = (array[index2], array[index1]);
    }
}