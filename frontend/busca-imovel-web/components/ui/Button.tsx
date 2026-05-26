import { ButtonHTMLAttributes } from "react";

export default function Button({
    className = "",
    ...props
}: ButtonHTMLAttributes<HTMLButtonElement>) {
    return (
        <button
            className={`inline-flex items-center justify-center rounded-3xl bg-primary px-4 py-3 text-sm font-semibold text-white shadow-sm transition hover:bg-primaryDark disabled:cursor-not-allowed disabled:opacity-60 ${className}`}
            {...props}
        />
    );
}
