import java.util.Scanner;
import java.util.function.DoubleUnaryOperator;

public class MaclaurinLab {
    // Функциональное определение: n-й член ряда
    private static DoubleUnaryOperator term(double x) {
        return n -> Math.pow(-1, n) * Math.pow(x, n);
    }

    // Вычисление суммы ряда с заданной точностью
    public static double maclaurin(double x, double eps) {
        double sum = 0.0;
        double currentTerm;
        int n = 0;
        do {
            currentTerm = term(x).applyAsDouble(n);
            sum += currentTerm;
            n++;
        } while (Math.abs(currentTerm) >= eps);
        return sum;
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Введите x: ");
        double x = sc.nextDouble();
        System.out.print("Введите точность eps: ");
        double eps = sc.nextDouble();

        double maclaurinValue = maclaurin(x, eps);
        double mathValue = 1.0 / (1.0 + x);

        System.out.println("Результаты вычислений:");
        System.out.println("Сумма ряда Маклорена: " + maclaurinValue);
        System.out.println("Значение через Math: " + mathValue);
        System.out.println("Разница: " + Math.abs(maclaurinValue - mathValue));

        sc.close();
    }
}
