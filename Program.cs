using System;

class City
{
    private int population;

    // Властивість для кількості жителів міста
    public int Population
    {
        get { return population; }
        set { population = value; }
    }

    // Перевантаження операторів

    // Перевантаження оператора "+" для збільшення кількості жителів
    public static City operator +(City city, int increase)
    {
        city.Population += increase;
        return city;
    }

    // Перевантаження оператора "-" для зменшення кількості жителів
    public static City operator -(City city, int decrease)
    {
        city.Population -= decrease;
        return city;
    }

    // Перевантаження оператора "==" для перевірки рівності кількості жителів
    public static bool operator ==(City city1, City city2)
    {
        return city1.Population == city2.Population;
    }

    // Перевантаження оператора "!=" для перевірки нерівності кількості жителів
    public static bool operator !=(City city1, City city2)
    {
        return !(city1 == city2);
    }

    // Перевантаження оператора "<" для перевірки меншої кількості жителів
    public static bool operator <(City city1, City city2)
    {
        return city1.Population < city2.Population;
    }

    // Перевантаження оператора ">" для перевірки більшої кількості жителів
    public static bool operator >(City city1, City city2)
    {
        return city1.Population > city2.Population;
    }

    // Перевизначення метода Equals для порівняння об'єктів
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        City other = (City)obj;
        return this.Population == other.Population;
    }

    // Генерація хеш-коду на основі кількості жителів
    public override int GetHashCode()
    {
        return Population.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        City city1 = new City();
        city1.Population = 10000;

        City city2 = new City();
        city2.Population = 15000;

        Console.WriteLine(city1 == city2);  // false
        Console.WriteLine(city1 != city2);  // true
        Console.WriteLine(city1 < city2);   // true
        Console.WriteLine(city1 > city2);   // false

        city1 += 5000;  // Збільшення кількості жителів
        Console.WriteLine(city1.Population);  // 15000

        city2 -= 3000;  // Зменшення кількості жителів
        Console.WriteLine(city2.Population);  // 12000

        Console.WriteLine(city1.Equals(city2));  // false

        Console.ReadLine();
    }
}
