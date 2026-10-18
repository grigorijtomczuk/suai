"use client";

import Link from "next/link";

import { useDemoAuth } from "@/app/providers/DemoAuthProvider";

export default function CabinetPage() {
  const { user, logout } = useDemoAuth();

  return (
    <main className="inner-page cabinet-page">
      <section className="page-intro container">
        <p className="eyebrow">Личный кабинет</p>
        <h1>{user ? `Рады видеть, ${user.name}.` : "Сначала войдите в профиль."}</h1>
        <p>
          Кабинет демонстрирует условный интерфейс и не ограничивает доступ к
          серверным данным.
        </p>
      </section>

      <section className="profile-card container">
        {user ? (
          <>
            <p className="section-number">ДЕМО-ПРОФИЛЬ</p>
            <dl className="profile-data">
              <div>
                <dt>Имя</dt>
                <dd>{user.name}</dd>
              </div>
              <div>
                <dt>Email</dt>
                <dd>{user.email}</dd>
              </div>
            </dl>
            <button className="primary-button" type="button" onClick={logout}>
              Выйти
            </button>
          </>
        ) : (
          <>
            <p>
              Сейчас вы просматриваете QuestCity как гость. После
              демонстрационного входа здесь появятся имя и email.
            </p>
            <Link className="primary-link" href="/auth/login">
              Перейти ко входу <span aria-hidden="true">→</span>
            </Link>
          </>
        )}
      </section>

      <p className="demo-warning container">
        Демонстрационный вход не является аутентификацией, не создаёт сессию и
        не обеспечивает авторизацию.
      </p>
    </main>
  );
}
