import { ReactNode } from "react";

interface BadgeProps {
    children: ReactNode;
    className?: string;
}

export default function Badge({ children, className = "" }: BadgeProps) {
    return (
        <span
            className={`inline-flex rounded-full bg-slate-100 px-3 py-1 text-xs font-medium uppercase tracking-wide text-slate-700 ${className}`}
        >
            {children}
        </span>
    );
}
