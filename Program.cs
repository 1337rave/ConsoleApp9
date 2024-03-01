using System;

class Employee
{
    private double salary;

    // Властивість для заробітної плати працівника
    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    // Перевантаження операторів

    // Перевантаження оператора "+" для збільшення зарплати на вказану кількість
    public static Employee operator +(Employee emp, double amount)
    {
        emp.Salary += amount;
        return emp;
    }

    // Перевантаження оператора "-" для зменшення зарплати на вказану кількість
    public static Employee operator -(Employee emp, double amount)
    {
        emp.Salary -= amount;
        return emp;
    }

    // Перевантаження оператора "==" для перевірки на рівність зарплат працівників
    public static bool operator ==(Employee emp1, Employee emp2)
    {
        return emp1.Salary == emp2.Salary;
    }

    // Перевантаження оператора "!=" для перевірки на нерівність зарплат працівників
    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return emp1.Salary != emp2.Salary;
    }

    // Перевантаження оператора "<" для перевірки меншої зарплати працівника
    public static bool operator <(Employee emp1, Employee emp2)
    {
        return emp1.Salary < emp2.Salary;
    }

    // Перевантаження оператора ">" для перевірки більшої зарплати працівника
    public static bool operator >(Employee emp1, Employee emp2)
    {
        return emp1.Salary > emp2.Salary;
    }

    // Перевизначення метода Equals для порівняння об'єктів
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Employee emp = (Employee)obj;
        return this.Salary == emp.Salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee();
        emp1.Salary = 3000;

        Employee emp2 = new Employee();
        emp2.Salary = 2500;

        Console.WriteLine(emp1 == emp2);  // false
        Console.WriteLine(emp1 != emp2);  // true
        Console.WriteLine(emp1 > emp2);   // true
        Console.WriteLine(emp1 < emp2);   // false

        emp1 += 500;  // Збільшення зарплати на 500
        Console.WriteLine(emp1.Salary);  // 3500

        emp2 -= 300;  // Зменшення зарплати на 300
        Console.WriteLine(emp2.Salary);  // 2200

        Console.WriteLine(emp1.Equals(emp2));  // false

        Console.ReadLine();
    }
}
