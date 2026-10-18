"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState, type FormEvent } from "react";

import { useDemoAuth } from "@/app/providers/DemoAuthProvider";

export default function LoginPage() {
  const router = useRouter();
  const { login } = useDemoAuth();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if (!email.trim() || !email.includes("@")) {
      setError("Введите корректный email.");
      return;
    }

    if (password.length < 8) {
      setError("Пароль должен содержать не менее 8 символов.");
      return;
    }

    setError("");
    login(email);
    router.push("/cabinet");
  }

  return (
    <main className="auth-page">
      <section className="auth-panel">
        <div className="auth-panel__heading">
          <p className="eyebrow">Возвращайтесь к приключениям</p>
          <h1>Вход в QuestCity</h1>
          <p>
            Введите любые корректные демонстрационные данные, чтобы увидеть
            состояние пользователя.
          </p>
        </div>

        <p className="demo-warning">
          Демонстрационный режим: данные не отправляются на сервер, пароль не
          сохраняется, а состояние сбросится после обновления страницы.
        </p>

        <form className="auth-form" onSubmit={handleSubmit} noValidate>
          <div className="form-field">
            <label htmlFor="login-email">Email</label>
            <input
              id="login-email"
              name="email"
              type="email"
              autoComplete="email"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
              required
            />
          </div>
          <div className="form-field">
            <label htmlFor="login-password">Пароль</label>
            <input
              id="login-password"
              name="password"
              type="password"
              autoComplete="current-password"
              minLength={8}
              value={password}
              onChange={(event) => setPassword(event.target.value)}
              required
            />
          </div>
          {error && (
            <p className="form-error" role="alert">
              {error}
            </p>
          )}
          <button className="primary-button" type="submit">
            Войти
          </button>
        </form>

        <p className="auth-switch">
          Впервые в QuestCity? <Link href="/auth/register">Создать профиль</Link>
        </p>
      </section>
    </main>
  );
}
