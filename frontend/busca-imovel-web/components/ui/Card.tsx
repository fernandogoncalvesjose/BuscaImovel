import { ReactNode } from "react";

interface CardProps {
    children: ReactNode;
    className?: string;
}

export default function Card({ children, className = "" }: CardProps) {
    return (
        <div
            className={`rounded-[2rem] border border-slate-200 bg-white shadow-soft ${className}`}
        >
            {children}
        </div>
    );
}
