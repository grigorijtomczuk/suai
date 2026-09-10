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
              О проекте
            </Link>
          </nav>
        </header>

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
              Узнать о проекте <span aria-hidden="true">↗</span>
            </Link>
          </div>

          <aside className="hero__note" aria-label="Для кого создан QuestCity">
            <span className="hero__note-label">Для кого</span>
            <p>
              Для жителей города и туристов, компаний друзей, пар и семей —
              всех, кто ищет новый сценарий для свободного вечера.
            </p>
          </aside>
        </div>
      </section>

      <section className="features container" aria-labelledby="features-title">
        <div className="section-heading">
          <p className="eyebrow">Возможности</p>
          <h2 id="features-title">Всё нужное для выбора — в одном месте</h2>
          <p>
            Первая версия задаёт основу сервиса. Эти направления будут
            последовательно развиваться в следующих лабораторных работах.
          </p>
        </div>

        <div className="feature-grid">
          <FeatureCard
            title="Каталог квестов"
            description="Просмотр городских квестов с основной информацией о каждом варианте."
          />
          <FeatureCard
            title="Удобный поиск"
            description="Поиск и подбор квестов по интересующим пользователя характеристикам."
          />
          <FeatureCard
            title="Избранные квесты"
            description="Сохранение интересных квестов для быстрого доступа и последующего выбора."
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
        <p>QuestCity · учебный проект</p>
        <Link className="text-link" href="/about">
          О проекте <span aria-hidden="true">→</span>
        </Link>
      </footer>
    </main>
  );
}
