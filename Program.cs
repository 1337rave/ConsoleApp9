using System;

class CreditCard
{
    private string cvc;
    private decimal balance;

    // Властивість для CVC коду
    public string CVC
    {
        get { return cvc; }
        set { cvc = value; }
    }

    // Властивість для суми грошей на картці
    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    // Конструктор класу CreditCard
    public CreditCard(string cvc, decimal balance)
    {
        this.cvc = cvc;
        this.balance = balance;
    }

    // Перевантаження операторів

    // Перевантаження оператора "+" для збільшення суми грошей на картці
    public static CreditCard operator +(CreditCard card, decimal amount)
    {
        card.Balance += amount;
        return card;
    }

    // Перевантаження оператора "-" для зменшення суми грошей на картці
    public static CreditCard operator -(CreditCard card, decimal amount)
    {
        card.Balance -= amount;
        return card;
    }

    // Перевантаження оператора "==" для перевірки рівності CVC коду
    public static bool operator ==(CreditCard card1, CreditCard card2)
    {
        return card1.CVC == card2.CVC;
    }

    // Перевантаження оператора "!=" для перевірки нерівності CVC коду
    public static bool operator !=(CreditCard card1, CreditCard card2)
    {
        return !(card1 == card2);
    }

    // Перевантаження оператора "<" для перевірки меншої кількості суми грошей
    public static bool operator <(CreditCard card1, CreditCard card2)
    {
        return card1.Balance < card2.Balance;
    }

    // Перевантаження оператора ">" для перевірки більшої кількості суми грошей
    public static bool operator >(CreditCard card1, CreditCard card2)
    {
        return card1.Balance > card2.Balance;
    }

    // Перевизначення методу Equals для порівняння об'єктів
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        CreditCard other = (CreditCard)obj;
        return this.CVC == other.CVC;
    }

    // Перевизначення методу GetHashCode для генерації хеш-коду
    public override int GetHashCode()
    {
        return CVC.GetHashCode();
    }

    // Генерація рахунку для власника карти
    public void GenerateInvoice(decimal amount)
    {
        Console.WriteLine($"Invoice generated for {amount} from card with CVC: {CVC}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу CreditCard
        CreditCard card1 = new CreditCard("123", 1000);
        CreditCard card2 = new CreditCard("456", 2000);

        Console.WriteLine($"Card 1 Balance: {card1.Balance}");
        Console.WriteLine($"Card 2 Balance: {card2.Balance}");

        card1 += 500; // Збільшення балансу першої картки
        Console.WriteLine($"Card 1 Balance after increase: {card1.Balance}");

        card2 -= 300; // Зменшення балансу другої картки
        Console.WriteLine($"Card 2 Balance after decrease: {card2.Balance}");

        // Перевірка рівності CVC коду
        Console.WriteLine($"Are CVC codes equal? {card1 == card2}");

        // Перевірка нерівності CVC коду
        Console.WriteLine($"Are CVC codes not equal? {card1 != card2}");

        // Перевірка більшості суми грошей
        Console.WriteLine($"Card 1 has more money than Card 2? {card1 > card2}");

        // Перевірка меншості суми грошей
        Console.WriteLine($"Card 2 has less money than Card 1? {card2 < card1}");

        Console.ReadLine();
    }
}
