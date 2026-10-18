"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";

import { useDemoAuth } from "@/app/providers/DemoAuthProvider";

const links = [
  { href: "/start", label: "Главная" },
  { href: "/quests", label: "Квесты" },
  { href: "/about", label: "О сервисе" },
  { href: "/cabinet", label: "Кабинет" },
];

function isActive(pathname: string, href: string): boolean {
  return pathname === href || pathname.startsWith(`${href}/`);
}

// Навигация является Client Component из-за usePathname и состояния пользователя.
export default function AppNav() {
  const pathname = usePathname();
  const { user, logout } = useDemoAuth();

  return (
    <header className="app-header">
      <div className="app-header__inner container">
        <Link className="brand" href="/start" aria-label="QuestCity — на главную">
          Quest<span>City</span>
        </Link>

        <nav className="app-nav" aria-label="Основная навигация">
          {links.map((link) => {
            const active = isActive(pathname, link.href);
            return (
              <Link
                className={`nav-link${active ? " nav-link--active" : ""}`}
                href={link.href}
                aria-current={active ? "page" : undefined}
                key={link.href}
              >
                {link.label}
              </Link>
            );
          })}
        </nav>

        <div className="auth-nav">
          {user ? (
            <>
              <span className="auth-nav__user">{user.name}</span>
              <button className="nav-action" type="button" onClick={logout}>
                Выйти
              </button>
            </>
          ) : (
            <Link
              className={`nav-link${
                pathname.startsWith("/auth/") ? " nav-link--active" : ""
              }`}
              href="/auth/login"
              aria-current={pathname === "/auth/login" ? "page" : undefined}
            >
              Войти
            </Link>
          )}
        </div>
      </div>
    </header>
  );
}
