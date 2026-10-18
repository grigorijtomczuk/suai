"use client";

import {
  createContext,
  useContext,
  useMemo,
  useState,
  type ReactNode,
} from "react";

// В контексте хранится только отображаемая информация учебного пользователя.
export type DemoUser = {
  name: string;
  email: string;
};

type DemoAuthContextValue = {
  user: DemoUser | null;
  login: (email: string) => void;
  register: (name: string, email: string) => void;
  logout: () => void;
};

const DemoAuthContext = createContext<DemoAuthContextValue | null>(null);

export default function DemoAuthProvider({
  children,
}: Readonly<{ children: ReactNode }>) {
  // Состояние живёт только в памяти вкладки и намеренно сбрасывается при обновлении.
  const [user, setUser] = useState<DemoUser | null>(null);

  const value = useMemo<DemoAuthContextValue>(
    () => ({
      user,
      login(email) {
        const name = email.split("@")[0]?.trim() || "Гость QuestCity";
        setUser({ name, email: email.trim() });
      },
      register(name, email) {
        setUser({ name: name.trim(), email: email.trim() });
      },
      logout() {
        setUser(null);
      },
    }),
    [user],
  );

  return (
    <DemoAuthContext.Provider value={value}>
      {children}
    </DemoAuthContext.Provider>
  );
}

// Явная ошибка помогает не использовать хук за пределами провайдера.
export function useDemoAuth(): DemoAuthContextValue {
  const context = useContext(DemoAuthContext);

  if (!context) {
    throw new Error("useDemoAuth должен использоваться внутри DemoAuthProvider");
  }

  return context;
}
