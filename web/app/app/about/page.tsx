import Link from "next/link";

// Массив позволяет выводить однотипные пункты без повторения разметки.
const selectionTips = [
  "Жанр и атмосфера",
  "Состав команды",
  "Уровень сложности",
  "Продолжительность",
  "Расположение",
  "Возрастные ограничения",
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
        <p className="eyebrow">О сервисе</p>
        <h1>Мы собираем городские приключения на одной карте.</h1>
        <p className="about-lead">
          Один вечер может стать детективом, экспедицией или путешествием в
          другую эпоху. QuestCity помогает выбрать подходящую историю без
          долгих поисков по сайтам разных организаторов.
        </p>
      </section>

      {/* Карточки группируют преимущества и ориентиры для выбора квеста. */}
      <section className="about-grid container" aria-label="Преимущества сервиса">
        <article className="about-card about-card--wide">
          <p className="section-number">01</p>
          <h2>Один сервис вместо десятка сайтов</h2>
          <p>
            QuestCity объединяет предложения городских квестов и помогает
            быстро сопоставить формат, атмосферу и условия участия. Всё важное
            для выбора находится рядом и представлено в понятном виде.
          </p>
        </article>

        <article className="about-card">
          <p className="section-number">02</p>
          <h2>Приключение для вашей компании</h2>
          <p className="entity-name">Ваш ход</p>
          <p>
            Выбирайте камерную загадку для двоих, семейное приключение или
            напряжённую игру для большой компании друзей.
          </p>
        </article>

        <article className="about-card">
          <p className="section-number">03</p>
          <h2>На что обратить внимание</h2>
          <ul className="section-list">
            {/* Текст пункта уникален, поэтому используется как стабильный key. */}
            {selectionTips.map((tip) => (
              <li key={tip}>{tip}</li>
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
