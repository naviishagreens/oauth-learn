using Faker;

namespace naviisha.common.DL
{
    public class FakerApi: IFaker
    {
        public int GetId()
        {
            return Random.Shared.Next(1, 1000);
        }

        public string GetAddress()
        {
            return Address.StreetAddress();
        }

        public string GetName()
        {
            return Name.FullName();
        }

        public string GetClass()
        {
            return ToRoman(Random.Shared.Next(1, 12));
        }

        public int GetAge()
        {
            return Random.Shared.Next(20, 55);
        }

        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public string GetSubject()
        {
            var subs = new string[] { "sub1", "sub2", "sub3", "sub4", "sub5" };
            return subs.Rand();
        }
    }
}
