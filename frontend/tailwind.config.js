/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      fontFamily: {
        sans: ["Inter", "sans-serif"],
      },
      colors: {
        primary: colors.indigo,
        success: colors.emerald,
        danger: colors.red,
        gray: colors.slate,
      },
    },
  },
  plugins: [],
};
