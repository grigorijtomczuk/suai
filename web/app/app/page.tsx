import Image from "next/image";
import Link from "next/link";

import FeatureCard from "@/app/ui/FeatureCard";

export default function Home() {
  return (
    <main>
      <section className="hero">
        <header className="site-header container">
          <Link className="brand" href="/" aria-label="QuestCity — на главную">
            Quest<span>City</span>
          </Link>
          <nav aria-label="Основная навигация">
            <Link className="nav-link" href="/about">
              О сервисе
            </Link>
          </nav>
        </header>

        {/* Hero объединяет основное предложение сервиса и тематический визуал. */}
        <div className="hero__content container">
          <div className="hero__copy">
            <p className="eyebrow">Город становится приключением</p>
            <h1>
              Найдите квест,
              <span> который запомнится.</span>
            </h1>
            <p className="hero__description">
              QuestCity объединяет городские квесты в одном интерфейсе, чтобы
              не искать площадки по разным сайтам и было проще сравнить
              подходящие варианты.
            </p>
            <Link className="primary-link" href="/about">
              Как это работает <span aria-hidden="true">↗</span>
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
            Детектив, хоррор, приключение или семейная история — сравните
            варианты и найдите тот самый сценарий для вашей команды.
          </p>
        </div>

        {/* Один компонент получает разные данные через типизированные props. */}
        <div className="feature-grid">
          <FeatureCard
            title="Каталог квестов"
            description="Изучайте городские квесты и всю важную информацию о каждом варианте."
          />
          <FeatureCard
            title="Удобный поиск"
            description="Подбирайте приключения по жанру, сложности и составу вашей команды."
          />
          <FeatureCard
            title="Избранные квесты"
            description="Сохраняйте понравившиеся варианты, чтобы спокойно сравнить их позже."
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
          Сервис поможет собрать разрозненную информацию об организаторах и
          площадках, сравнить подходящие варианты и уверенно выбрать квест под
          конкретную компанию.
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
