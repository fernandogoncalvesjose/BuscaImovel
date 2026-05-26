import { SelectHTMLAttributes } from "react";

export default function Select({
    className = "",
    children,
    ...props
}: SelectHTMLAttributes<HTMLSelectElement>) {
    return (
        <select
            className={`w-full rounded-3xl border border-slate-200 bg-white px-4 py-3 text-sm text-slate-900 outline-none transition focus:border-primary focus:ring-2 focus:ring-primary/10 ${className}`}
            {...props}
        >
            {children}
        </select>
    );
}
