import type { ReactNode } from "react";
import "./globals.css";
import type { Metadata } from "next";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
    title: "Busca Imóvel",
    description: "Marketplace de imóveis em São Paulo",
};

export default function RootLayout({ children }: { children: ReactNode }) {
    return (
        <html lang="pt-BR">
            <body className={`${inter.className} bg-surface text-slate-900`}>
                {children}
            </body>
        </html>
    );
}
