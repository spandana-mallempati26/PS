import type { Config } from "tailwindcss";

export default {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
    "./styles/**/*.{css}" 
  ],
  theme: {
    extend: {
      colors: {
        background: "var(--background)",
        foreground: "var(--foreground)",
        danger: "#e3342f", // Example color for danger
        success: "#38c172", // Example color for success
        warning: "#ffed4a", // Example color for warning
      },
    },
  },
  darkMode: 'class',
  plugins: [],
} satisfies Config;
