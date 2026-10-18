import Link from "next/link";

import { quests } from "@/app/data/quests";

export default function QuestsPage() {
  return (
    <main className="inner-page">
      <section className="page-intro container">
        <p className="eyebrow">Каталог</p>
        <h1>Выберите свою следующую историю</h1>
        <p>
          Три разных сценария — от неспешного знакомства с загадками до
          сложной командной экспедиции.
        </p>
      </section>

      <section className="quest-grid container" aria-label="Каталог квестов">
        {quests.map((quest, index) => (
          <article className="quest-card" key={quest.id}>
            <p className="section-number">{String(index + 1).padStart(2, "0")}</p>
            <p className="quest-card__genre">{quest.genre}</p>
            <h2>{quest.title}</h2>
            <p className="quest-card__summary">{quest.summary}</p>
            <dl className="quest-facts">
              <div>
                <dt>Сложность</dt>
                <dd>{quest.difficulty}</dd>
              </div>
              <div>
                <dt>Время</dt>
                <dd>{quest.duration} минут</dd>
              </div>
            </dl>
            <Link className="text-link" href={`/quests/${quest.id}`}>
              Подробнее <span aria-hidden="true">→</span>
            </Link>
          </article>
        ))}
      </section>
    </main>
  );
}
