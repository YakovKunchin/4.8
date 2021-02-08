namespace lab1
{
    public static class ArrayExtensions
    {
        public static void FillArrayByRow(this int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            for (var j = 0; j < arr.GetLength(1); j++)
                arr[i, j] = i + j;
        }

        public static void FillArrayByColumn(this int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            for (var j = 0; j < arr.GetLength(1); j++)
                arr[j, i] = i + j;
        }
    }
}