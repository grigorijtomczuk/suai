import type { Metadata } from "next";

import DemoAuthProvider from "@/app/providers/DemoAuthProvider";
import AppNav from "@/app/ui/AppNav";

import "./globals.css";

// Общие метаданные применяются ко всем маршрутам приложения.
export const metadata: Metadata = {
  title: "QuestCity",
  description: "Агрегатор городских квестов",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    // Атрибут сообщает Next.js, что плавная прокрутка задана намеренно.
    <html lang="ru" data-scroll-behavior="smooth">
      <body>
        {/* Провайдер сохраняется при переходах и передаёт одно состояние всем страницам. */}
        <DemoAuthProvider>
          <AppNav />
          {children}
        </DemoAuthProvider>
      </body>
    </html>
  );
}
