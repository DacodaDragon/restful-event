using System.Numerics;
namespace RestfulEvents.Utility
{
    public static class EnumUtil
    {
        public static class EnumCaster 
        {
            public static byte ToByte<T>(T enumValue) where T : Enum => Convert<T, byte>(enumValue);
            public static T ToEnum<T>(byte enumValue) where T : Enum => Convert<byte, T>(enumValue);
            public static int ToInt<T>(T enumValue) where T : Enum => Convert<T, int>(enumValue);
            public static T ToEnum<T>(int enumValue) where T : Enum => Convert<int, T>(enumValue);

            private static Tb Convert<Ta, Tb>(Ta source) => CachedConverter<Ta, Tb>.Converter.Invoke(source);

            public static class CachedConverter<Ta, Tb> 
            {
                public static Func<Ta, Tb> Converter = Reflection.CreateConversionExpression<Ta, Tb>();
            }
        }

        public static class EnumValuesHolder<T> where T : Enum 
        {
            public static T[] AllValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static T[] GetAllFlags<T>(this T flaggedEnum) where T : Enum
        {
            return EnumValuesHolder<T>.AllValues.Where(x => flaggedEnum.HasFlag(x)).ToArray();
        }

        public static T CombineFlagsByte<T>(this T[] enumValues) where T : Enum
        {
            if (enumValues is null) throw new ArgumentNullException(nameof(enumValues));
            byte result = 0;
            for (int i = 0; i < enumValues.Length; i++)
                result |= EnumCaster.ToByte(enumValues[i]);
            return EnumCaster.ToEnum<T>(result);
        }
    }
}
