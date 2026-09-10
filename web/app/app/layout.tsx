import type { Metadata } from "next";
import "./globals.css";

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
    <html lang="ru" data-scroll-behavior="smooth">
      <body>{children}</body>
    </html>
  );
}
