using System.Diagnostics;

class Program
{
    static double CalculateDiscount(double price, double discountRate)
    {
        Debug.Assert(price > 0, "Цена должна быть больше нуля");
        Debug.Assert(discountRate >= 0 && discountRate <= 1, "Ставка дисконта должна быть в диапазоне от 0 до 1");

        double discount = price * discountRate;
        Debug.Assert(discount <= price, "Скидка не может превышать исходную цену");

        return discount;
    }

    static void Main()
    {
        Console.WriteLine(CalculateDiscount(100, 2));
    }
}