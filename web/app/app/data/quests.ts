// Тип описывает одну предметную сущность каталога городских квестов.
export type Quest = {
  id: string;
  title: string;
  summary: string;
  genre: string;
  difficulty: string;
  duration: number;
  teamSize: string;
  address: string;
};

// Учебные данные хранятся в TypeScript-файле и не являются базой данных.
export const quests: Quest[] = [
  {
    id: "midnight-archive",
    title: "Полуночный архив",
    summary:
      "Раскройте тайну исчезнувшего архивариуса, пока старые часы не пробили полночь.",
    genre: "Детектив",
    difficulty: "Средняя",
    duration: 75,
    teamSize: "2–5 игроков",
    address: "Литейный проспект, 28",
  },
  {
    id: "neva-signal",
    title: "Сигнал над Невой",
    summary:
      "Найдите источник загадочного радиосигнала в атмосферной экспедиции по городу.",
    genre: "Приключение",
    difficulty: "Высокая",
    duration: 90,
    teamSize: "3–6 игроков",
    address: "Петроградская набережная, 8",
  },
  {
    id: "clockwork-house",
    title: "Дом часовщика",
    summary:
      "Запустите остановившийся механизм дома и верните его хозяину потерянное время.",
    genre: "Мистика",
    difficulty: "Начальная",
    duration: 60,
    teamSize: "2–4 игрока",
    address: "Гороховая улица, 41",
  },
];

// Поиск вынесен в функцию, чтобы каталог и динамическая страница работали с одними данными.
export function getQuest(id: string): Quest | undefined {
  return quests.find((quest) => quest.id === id);
}
