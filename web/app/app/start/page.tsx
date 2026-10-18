import Image from "next/image";
import Link from "next/link";

import FeatureCard from "@/app/ui/FeatureCard";

export default function StartPage() {
  return (
    <main>
      <section className="hero">
        <div className="hero__content container">
          <div className="hero__copy">
            <p className="eyebrow">Город становится приключением</p>
            <h1>
              Найдите квест,
              <span> который запомнится.</span>
            </h1>
            <p className="hero__description">
              QuestCity объединяет городские квесты в одном интерфейсе, чтобы
              вы могли сравнить сюжеты, сложность и формат игры без долгих
              поисков.
            </p>
            <Link className="primary-link" href="/quests">
              Смотреть квесты <span aria-hidden="true">↗</span>
            </Link>
          </div>

          <figure className="hero__visual">
            {/* Priority ускоряет загрузку изображения в первом экране. */}
            <Image
              src="/hero.jpg"
              alt="Команда участников разгадывает тайну квеста"
              fill
              priority
              sizes="(max-width: 820px) 100vw, 42vw"
            />
            <figcaption>
              <span>Подберите приключение</span>
              Для друзей, пары или всей семьи
            </figcaption>
          </figure>
        </div>
      </section>

      <section className="features container" aria-labelledby="features-title">
        <div className="section-heading">
          <p className="eyebrow">Возможности</p>
          <h2 id="features-title">Всё нужное для выбора — в одном месте</h2>
          <p>
            Детектив, мистика или городское приключение — сравните варианты и
            найдите сценарий для своей команды.
          </p>
        </div>

        {/* Один компонент получает разные данные через типизированные props. */}
        <div className="feature-grid">
          <FeatureCard
            title="Каталог квестов"
            description="Изучайте сюжеты и основные параметры каждого приключения."
          />
          <FeatureCard
            title="Честное сравнение"
            description="Сопоставляйте жанр, сложность, длительность и размер команды."
          />
          <FeatureCard
            title="Личный кабинет"
            description="Используйте демонстрационный профиль, чтобы познакомиться с сервисом."
          />
        </div>
      </section>

      <section className="mission container" aria-labelledby="mission-title">
        <p className="mission__index">01</p>
        <div>
          <p className="eyebrow">Зачем нужен QuestCity</p>
          <h2 id="mission-title">
            Меньше времени на поиск. Больше — на впечатления.
          </h2>
        </div>
        <p>
          Сервис собирает важную информацию о квестах рядом, чтобы выбор
          следующего приключения был быстрым и понятным.
        </p>
      </section>

      <footer className="site-footer container">
        <p>QuestCity · городские квесты в одном месте</p>
        <Link className="text-link" href="/about">
          О сервисе <span aria-hidden="true">→</span>
        </Link>
      </footer>
    </main>
  );
}
