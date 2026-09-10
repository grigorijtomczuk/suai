import Link from "next/link";

const plannedSections = [
  "Главная",
  "Каталог квестов",
  "Страница квеста",
  "Избранное",
  "Бронирование",
  "Личный кабинет",
  "Авторизация",
  "О проекте",
];

export default function AboutPage() {
  return (
    <main className="about-page">
      <header className="site-header container">
        <Link className="brand" href="/" aria-label="QuestCity — на главную">
          Quest<span>City</span>
        </Link>
        <nav aria-label="Основная навигация">
          <Link className="nav-link" href="/">
            Главная
          </Link>
        </nav>
      </header>

      <section className="about-hero container">
        <p className="eyebrow">О проекте</p>
        <h1>QuestCity — единая точка входа в мир городских квестов.</h1>
        <p className="about-lead">
          Цель разработки — создать веб-приложение-агрегатор, которое поможет
          находить и выбирать квесты, не переключаясь между сайтами разных
          организаторов.
        </p>
      </section>

      <section className="about-grid container" aria-label="Концепция проекта">
        <article className="about-card about-card--wide">
          <p className="section-number">01</p>
          <h2>Будущий результат</h2>
          <p>
            К завершению курса QuestCity должен стать связанным
            веб-приложением: пользователь сможет работать с каталогом,
            просматривать отдельные квесты и выполнять основные сценарии
            выбора и бронирования.
          </p>
        </article>

        <article className="about-card">
          <p className="section-number">02</p>
          <h2>Главная сущность</h2>
          <p className="entity-name">Квест</p>
          <p>
            Именно вокруг информации о квестах будут строиться будущие разделы
            и пользовательские сценарии приложения.
          </p>
        </article>

        <article className="about-card">
          <p className="section-number">03</p>
          <h2>Предполагаемые разделы</h2>
          <ul className="section-list">
            {plannedSections.map((section) => (
              <li key={section}>{section}</li>
            ))}
          </ul>
        </article>
      </section>

      <footer className="about-footer container">
        <Link className="text-link" href="/">
          <span aria-hidden="true">←</span> Вернуться на главную
        </Link>
      </footer>
    </main>
  );
}
