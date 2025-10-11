public class MultiThreadLab {
	public static void main(String[] args) {
		Object lock = new Object(); // общий объект синхронизации

		TimerThread timer = new TimerThread(lock);
		MessageThread message5 = new MessageThread(lock, 5, "Сообщение каждые 5 секунд");
		MessageThread message7 = new MessageThread(lock, 7, "Сообщение каждые 7 секунд");

		timer.start();
		message5.start();
		message7.start();
	}
}

// Поток-хронометр
class TimerThread extends Thread {
	private final Object lock;
	private int secondsPassed = 0;

	public TimerThread(Object lock) {
		this.lock = lock;
	}

	@Override
	public void run() {
		try {
			while (true) {
				Thread.sleep(1000);
				secondsPassed++;
				System.out.println("Прошло секунд: " + secondsPassed);
				synchronized (lock) {
					lock.notifyAll(); // оповещаем другие потоки
				}
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}

// Поток, который выводит сообщение message каждые interval секунд
class MessageThread extends Thread {
	private final Object lock;
	private final int interval;
	private final String message;
	private int currentSeconds = 0;

	public MessageThread(Object lock, int interval, String message) {
		this.lock = lock;
		this.interval = interval;
		this.message = message;
	}

	@Override
	public void run() {
		try {
			while (true) {
				synchronized (lock) {
					lock.wait(); // ждём уведомления от хронометра
					currentSeconds++;
					if (currentSeconds % interval == 0) {
						System.out.println("\t" + message);
					}
				}
			}
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
	}
}
