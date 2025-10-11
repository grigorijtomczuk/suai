import java.text.DecimalFormat;
import java.util.Scanner;
import java.util.function.DoubleUnaryOperator;

public class MaclaurinLab {
	// n-й член ряда для аргумента x
	private static DoubleUnaryOperator member(double x) {
		return n -> Math.pow(-1, n) * Math.pow(x, n);
	}

	// Вычисление суммы ряда с заданной точностью eps
	private static double maclaurin(double x, double eps) {
		double currentMember;
		double sum = 0.0;
		int n = 0;

		do {
			currentMember = member(x).applyAsDouble(n);
			sum += currentMember;
			n++;
		} while (Math.abs(currentMember) >= eps);

		return sum;
	}

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		DecimalFormat df = new DecimalFormat();
		double x, eps;

		df.setMaximumFractionDigits(8);

		// ввод x
		while (true) {
			System.out.print("Введите x ∈ (-1; 1): ");
			if (sc.hasNextDouble()) {
				x = sc.nextDouble();
				if (x > -1 && x < 1)
					break;
				else
					System.err.println("Ошибка: x должен быть в диапазоне (-1; 1).");
			} else {
				System.err.println("Ошибка: нужно ввести число.");
				sc.next(); // очищаем неверный ввод
			}
		}

		// ввод eps
		while (true) {
			System.out.print("Введите точность eps ∈ (0; 1): ");
			if (sc.hasNextDouble()) {
				eps = sc.nextDouble();
				if (eps > 0 && eps < 1)
					break;
				else
					System.err.println("Ошибка: eps должно быть в диапазоне (0; 1).");
			} else {
				System.err.println("Ошибка: нужно ввести число.");
				sc.next();
			}
		}

		double maclaurinValue = maclaurin(x, eps);
		double mathValue = 1.0 / (1.0 + x);

		System.out.println("Значение через разложение в ряд Маклорена: " + df.format(maclaurinValue));
		System.out.println("Вычисленное значение: " + df.format(mathValue));
		System.out.println("Разница: " + df.format(Math.abs(maclaurinValue - mathValue)));

		sc.close();
	}
}
