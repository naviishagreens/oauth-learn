namespace naviisha.common
{
    public static class IExtensions
    {
        public static T Rand<T>(this IList<T> list)
        {
            var cnt = list.Count();
            return list[Random.Shared.Next(0, cnt - 1)];
        }

        public static T Rand<T>(this T[] list)
        {
            var cnt = list.Length;
            return list[Random.Shared.Next(0, cnt - 1)];
        }
    }
}