import { useState } from "react";

interface ImageWithFallbackProps {
    src?: string | null;
    alt: string;
    className?: string;
}

const DEFAULT_IMAGE =
    "https://images.unsplash.com/photo-1494526585095-c41746248156?auto=format&fit=crop&w=900&q=80";

export default function ImageWithFallback({
    src,
    alt,
    className = "",
}: ImageWithFallbackProps) {
    const [imgSrc, setImgSrc] = useState(src || DEFAULT_IMAGE);

    return (
        <img
            src={imgSrc}
            alt={alt}
            className={className}
            onError={() => {
                if (imgSrc !== DEFAULT_IMAGE) {
                    setImgSrc(DEFAULT_IMAGE);
                }
            }}
        />
    );
}
