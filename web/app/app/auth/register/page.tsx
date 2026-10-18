"use client";

import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState, type FormEvent } from "react";

import { useDemoAuth } from "@/app/providers/DemoAuthProvider";

export default function RegisterPage() {
  const router = useRouter();
  const { register } = useDemoAuth();
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [passwordConfirmation, setPasswordConfirmation] = useState("");
  const [error, setError] = useState("");

  function handleSubmit(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if (!name.trim()) {
      setError("Введите имя.");
      return;
    }

    if (!email.trim() || !email.includes("@")) {
      setError("Введите корректный email.");
      return;
    }

    if (password.length < 8) {
      setError("Пароль должен содержать не менее 8 символов.");
      return;
    }

    if (password !== passwordConfirmation) {
      setError("Пароли не совпадают.");
      return;
    }

    setError("");
    register(name, email);
    router.push("/cabinet");
  }

  return (
    <main className="auth-page">
      <section className="auth-panel">
        <div className="auth-panel__heading">
          <p className="eyebrow">Начните исследовать город</p>
          <h1>Создание профиля</h1>
          <p>
            Профиль существует только до обновления вкладки и нужен для
            знакомства с интерфейсом.
          </p>
        </div>

        <p className="demo-warning">
          Это прототип регистрации без базы данных, серверной сессии и проверки
          прав доступа.
        </p>

        <form className="auth-form" onSubmit={handleSubmit} noValidate>
          <div className="form-field">
            <label htmlFor="register-name">Имя</label>
            <input
              id="register-name"
              name="name"
              type="text"
              autoComplete="name"
              value={name}
              onChange={(event) => setName(event.target.value)}
              required
            />
          </div>
          <div className="form-field">
            <label htmlFor="register-email">Email</label>
            <input
              id="register-email"
              name="email"
              type="email"
              autoComplete="email"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
              required
            />
          </div>
          <div className="form-field">
            <label htmlFor="register-password">Пароль</label>
            <input
              id="register-password"
              name="password"
              type="password"
              autoComplete="new-password"
              minLength={8}
              value={password}
              onChange={(event) => setPassword(event.target.value)}
              required
            />
          </div>
          <div className="form-field">
            <label htmlFor="register-password-confirmation">Повторите пароль</label>
            <input
              id="register-password-confirmation"
              name="passwordConfirmation"
              type="password"
              autoComplete="new-password"
              minLength={8}
              value={passwordConfirmation}
              onChange={(event) => setPasswordConfirmation(event.target.value)}
              required
            />
          </div>
          {error && (
            <p className="form-error" role="alert">
              {error}
            </p>
          )}
          <button className="primary-button" type="submit">
            Создать профиль
          </button>
        </form>

        <p className="auth-switch">
          Уже есть профиль? <Link href="/auth/login">Войти</Link>
        </p>
      </section>
    </main>
  );
}
