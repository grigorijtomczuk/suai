import Link from "next/link";
import { notFound } from "next/navigation";

import { getQuest, quests } from "@/app/data/quests";

// Известные id позволяют заранее подготовить динамические страницы при сборке.
export function generateStaticParams() {
  return quests.map((quest) => ({ id: quest.id }));
}

export default async function QuestPage({
  params,
}: {
  params: Promise<{ id: string }>;
}) {
  // В актуальном App Router params является Promise и читается через await.
  const { id } = await params;
  const quest = getQuest(id);

  if (!quest) {
    notFound();
  }

  return (
    <main className="inner-page quest-detail">
      <section className="page-intro container">
        <p className="eyebrow">{quest.genre}</p>
        <h1>{quest.title}</h1>
        <p>{quest.summary}</p>
      </section>

      <section className="detail-panel container" aria-label="Параметры квеста">
        <dl className="detail-grid">
          <div>
            <dt>Сложность</dt>
            <dd>{quest.difficulty}</dd>
          </div>
          <div>
            <dt>Продолжительность</dt>
            <dd>{quest.duration} минут</dd>
          </div>
          <div>
            <dt>Команда</dt>
            <dd>{quest.teamSize}</dd>
          </div>
          <div>
            <dt>Адрес</dt>
            <dd>{quest.address}</dd>
          </div>
        </dl>
        <Link className="text-link" href="/quests">
          <span aria-hidden="true">←</span> Вернуться к каталогу
        </Link>
      </section>
    </main>
  );
}
