import { redirect } from "next/navigation";

// Корневой адрес сразу открывает содержательную стартовую страницу сервиса.
export default function HomePage() {
  redirect("/start");
}
